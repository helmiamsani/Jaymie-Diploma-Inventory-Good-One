using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Linear
{
    public class Inventory : MonoBehaviour
    {
        public GUISkin invSkin;
        public GUIStyle boxStyle;
        public GUIStyle baseBackgroundStyle;

        #region Variables
        public List<Item> inv = new List<Item>(); // List of items
        public Item selectedItem;
        public bool showInv;

        public Vector2 scr;
        public Vector2 scrollPos;

        public int money;

        public ItemType sortType = ItemType.All;

        public Transform dropLocation;
        [System.Serializable]        
        public struct equipment
        {
            public string name;
            public Transform location;
            public GameObject curItem;
        };
        public equipment[] equipmentSlots;
        #endregion

        private void Start()
        {
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            inv.Add(ItemData.CreateItem(0));
            inv.Add(ItemData.CreateItem(1));
            inv.Add(ItemData.CreateItem(2));
            inv.Add(ItemData.CreateItem(81));
            inv.Add(ItemData.CreateItem(61));
        }

        private void Update()
        {
            if (Input.GetKey(KeyCode.I))
            {
                inv.Add(ItemData.CreateItem(Random.Range(0, 5)));
            }
            if (Input.GetKeyDown(KeyCode.O))
            {
                inv[3].Amount += 1;
                inv[4].Amount += 1;
            }
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                showInv = !showInv;
                if (showInv)
                {
                    Time.timeScale = 0;
                    //Cursor.lockState = CursorLockMode.Confined; // Jaymie original but I reckon None is better.
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                    return;                    
                }
                else
                {
                    Time.timeScale = 1;
                    Cursor.lockState = CursorLockMode.Locked;
                    Cursor.visible = false;
                    return;
                }
            }
        }

        private void OnGUI()
        {
            if (showInv)
            {
                scr.x = Screen.width / 16;
                scr.y = Screen.height / 9;

                // All Comment code are originial from Jaymie
                //GUI.Box(new Rect(0, 0, scr.x * 8, Screen.height), "Inventory");
                GUI.Box(new Rect(0, 0, scr.x * 9, Screen.height), "");
                GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "Inventory", baseBackgroundStyle);

                if (GUI.Button(new Rect(3f * scr.x, 0, scr.x, 0.25f * scr.y), "All"))
                {
                    sortType = ItemType.All;
                }
                for (int i = 0; i < (int)ItemType.All - 1; i++)
                {
                    ItemType a  = (ItemType)i;
                    if (GUI.Button(new Rect((4f+i) * scr.x, 0, scr.x, 0.25f * scr.y), a.ToString()))
                    {
                        sortType = (ItemType)i;
                    }
                }
                #region Jaymie's Trash
                /*
                if (GUI.Button(new Rect(3f * scr.x, 0, scr.x, 0.25f * scr.y), "All"))
                {
                    sortType = "All";
                }
                if (GUI.Button(new Rect(4f * scr.x, 0, scr.x, 0.25f * scr.y), "Food"))
                {
                    sortType = "Food";
                }
                if (GUI.Button(new Rect(5f * scr.x, 0, scr.x, 0.25f * scr.y), "Armour"))
                {
                    sortType = "Armour";
                }
                if (GUI.Button(new Rect(6f * scr.x, 0, scr.x, 0.25f * scr.y), "Weapon"))
                {
                    sortType = "Weapon";
                }
                if (GUI.Button(new Rect(7f * scr.x, 0, scr.x, 0.25f * scr.y), "Ingredient"))
                {
                    sortType = "Ingredient";
                }
                */
                #endregion
                Display();
                if (selectedItem != null)
                {
                    GUI.Box(new Rect(4.375f * scr.x, 0.75f * scr.y, 3 * scr.x, 0.35f * scr.y), selectedItem.Name, boxStyle);
                    GUI.skin = invSkin;
                    GUI.Box(new Rect(4.375f* scr.x, 1.25f*scr.y, 3*scr.x, 3*scr.y), selectedItem.Icon);
                    GUI.Box(new Rect(4.375f * scr.x, 4.5f * scr.y, 3 * scr.x, 2 * scr.y), selectedItem.Description);
                    GUI.skin = null; 
                }
                else
                { return; }
                ItemUse(selectedItem.Type);
            }            
        }

        void Display()
        {
            int b = 0;
            if (!(sortType == ItemType.All))
            {
                //ItemType type = (ItemType)System.Enum.Parse(typeof(ItemType), sortType);
                int a = 0; // Amount of that type
                int s = 0; // Slot position
                for (int i = 0; i < inv.Count; i++)
                {
                    if(inv[i].Type == sortType) // Find our type
                    {
                        a++; // Increase for each item it finds
                    }
                }
                if (a <= 34)
                {
                    for (int i = 0; i < inv.Count; i++)
                    {
                        if (inv[i].Type == sortType)
                        {
                            if (GUI.Button(new Rect(0.5f * scr.x, 0.75f * scr.y + s * (0.35f * scr.y), 3 * scr.x, 0.35f * scr.y), inv[i].Name))
                            {
                                selectedItem = inv[i];
                            }
                            s++;
                        }
                    }
                }
                else
                {
                    scrollPos = GUI.BeginScrollView(new Rect(0f, 0.25f * scr.y, 3.75f * scr.x, 8.5f * scr.y), scrollPos, new Rect(0, 0, 0, 0.5f * scr.y + ((inv.Count - 34) * (0.25f * scr.y))), false, true);

                    for (int i = 0; i < inv.Count; i++)
                    {
                        if(inv[i].Type == sortType)
                        {
                            if (GUI.Button(new Rect(0.5f * scr.x, 0.75f * scr.y + s * (0.35f * scr.y), 3 * scr.x, 0.35f * scr.y), inv[i].Name))
                            {
                                selectedItem = inv[i];
                            }
                            s++;
                        }
                    }
                    GUI.EndScrollView();
                }
            }
            else
            {
                if (inv.Count <= 34) // If we have 34 or less (space at top and bottom)
                {
                    GenInvButton(b,b);
                }
                else // more than 34 Item
                {
                    // Our movable scroll position = the start of our viewable area ((our View Window), Our current scroll position, scroll zone (extra space), can we see our horizontal bar?, can we see the vertical bar?)
                    scrollPos = GUI.BeginScrollView(new Rect(0f, 0.25f * scr.y, 3.75f * scr.x, 8.5f * scr.y), scrollPos, new Rect(0, 0, 0, 0.5f * scr.y + ((inv.Count - 34) * (0.25f * scr.y))), false, true);
                    GenInvButton(b,b);

                    // End 
                    GUI.EndScrollView();
                }
            }
        }

        void GenInvButton(int i, int s)
        {
            for (i = 0; i < inv.Count; i++)
            {
                if (GUI.Button(new Rect(0.5f * scr.x, 0.75f * scr.y + s * (0.35f * scr.y), 3 * scr.x, 0.35f * scr.y), inv[i].Name))
                {
                    selectedItem = inv[i];
                }
                s++;
            }
        }

        void ItemUse(ItemType type)
        {
            switch(type)
            {
                case ItemType.Ingredient:
                    break;
                case ItemType.Potion:
                    break;
                case ItemType.Scroll:
                    break;
                case ItemType.Food:
                    break;
                case ItemType.Armour:
                    if (equipmentSlots[0].curItem == null || selectedItem.Name != equipmentSlots[0].curItem.name)
                    {
                        if (GUI.Button(new Rect(4.75f * scr.x, 6.5f * scr.y, scr.x, 0.5f * scr.y), "Equip"))
                        {
                            if (equipmentSlots[0].curItem != null)
                            {
                                Destroy(equipmentSlots[0].curItem);
                            }
                            GameObject curItem = Instantiate(selectedItem.MeshType, equipmentSlots[0].location);
                            equipmentSlots[0].curItem = curItem;
                            curItem.name = selectedItem.Name;
                        }
                    }
                    else
                    {
                        if (GUI.Button(new Rect(4.75f * scr.x, 6.5f * scr.y, scr.x, 0.5f * scr.y), "Unequip"))
                        {
                            Destroy(equipmentSlots[0].curItem);
                        }
                    }
                    break;
                case ItemType.Weapon:
                    if(equipmentSlots[1].curItem == null || selectedItem.Name != equipmentSlots[1].curItem.name)
                    {
                        if (GUI.Button(new Rect(4.75f * scr.x, 6.5f * scr.y, scr.x, 0.5f * scr.y), "Equip"))
                        {
                            if(equipmentSlots[1].curItem != null)
                            {
                                Destroy(equipmentSlots[1].curItem);
                            }
                            GameObject curItem = Instantiate(selectedItem.MeshType, equipmentSlots[1].location);
                            equipmentSlots[1].curItem = curItem;
                            curItem.name = selectedItem.Name;
                        }
                    }
                    else
                    {
                        if (GUI.Button(new Rect(4.75f * scr.x, 6.5f * scr.y, scr.x, 0.5f * scr.y), "Unequip"))
                        {
                            Destroy(equipmentSlots[1].curItem);
                        }
                    }
                        break;
                case ItemType.Craftable:
                    break;
                case ItemType.Money:
                    break;
                case ItemType.Quest:
                    break;
                case ItemType.Misc:
                    break;
            }
            if (GUI.Button(new Rect(6f *scr.x, 6.5f*scr.y, scr.x, 0.5f*scr.y), "Discard"))
            {
                for (int i = 0; i < equipmentSlots.Length; i++)
                {
                    // Check equiped items
                    if (equipmentSlots[i].curItem != null && selectedItem.Name == equipmentSlots[i].curItem.name)
                    {
                        // If it is deleted 
                        Destroy(equipmentSlots[i].curItem);
                    }
                }
                // Spawn in from
                GameObject droppedItem = Instantiate(selectedItem.MeshType, dropLocation.position, Quaternion.identity);
                droppedItem.name = selectedItem.Name;
                droppedItem.AddComponent<Rigidbody>().useGravity = true;
                // reduce or delete
                if(selectedItem.Amount > 1)
                {
                    selectedItem.Amount--;
                }
                else
                {
                    inv.Remove(selectedItem);
                    selectedItem = null;
                    return;
                }
            }
        }
    }
}
