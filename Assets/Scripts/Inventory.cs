using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Linear
{
    public class Inventory : MonoBehaviour
    {
        public GUISkin invSkin;
        public GUIStyle boxStyle;
        #region Variables
        public List<Item> inv = new List<Item>(); // List of items
        public Item selectedItem;
        public bool showInv;

        public Vector2 scr;
        public Vector2 scrollPos;

        public int money;

        public string sortType = "";

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
        }

        private void Update()
        {
            if (Input.GetKey(KeyCode.I))
            {
                inv.Add(ItemData.CreateItem(Random.Range(0, 4)));
            }
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                showInv = !showInv;
                if (showInv)
                {
                    Time.timeScale = 0;
                    Cursor.lockState = CursorLockMode.Confined;
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

                GUI.Box(new Rect(0, 0, scr.x * 8, Screen.height), "");
                Display();
                if (selectedItem != null)
                {
                    GUI.Box(new Rect(4.375f * scr.x, 0.25f * scr.y, 3 * scr.x, 0.35f * scr.y), selectedItem.Name);
                    GUI.skin = invSkin;
                    GUI.DrawTexture(new Rect(4.375f* scr.x, 0.75f*scr.y, 3*scr.x, 3*scr.y), selectedItem.Icon);
                    GUI.Box(new Rect(4.375f * scr.x, 4f * scr.y, 3 * scr.x, 2 * scr.y), selectedItem.Description);
                    GUI.skin = null; 
                }
                else
                { return; }
            }            
        }

        void Display()
        {
            if(inv.Count <= 34) // If we have 34 or less (space at top and bottom)
            {
                for (int i = 0; i < inv.Count; i++)
                {
                    if(GUI.Button(new Rect(0.5f*scr.x, 0.25f*scr.y + i * (0.25f * scr.y), 3*scr.x, 0.25f*scr.y), inv[i].Name))
                    {
                        selectedItem = inv[i];
                    }
                }
            }
            else // more than 34 Item
            {
                // Our movable scroll position = the start of our viewable area ((our View Window), Our current scroll position, scroll zone (extra space), can we see our horizontal bar?, can we see the vertical bar?)
                scrollPos = GUI.BeginScrollView(new Rect(0f, 0.25f * scr.y, 3.75f * scr.x, 8.5f * scr.y), scrollPos, new Rect(0, 0, 0, 0.5f * scr.y + ((inv.Count - 34) * (0.25f * scr.y))), false, true);

                for (int i = 0; i < inv.Count; i++)
                {
                    if (GUI.Button(new Rect(0.5f * scr.x, 0.25f * scr.y + i * (0.25f * scr.y), 3 * scr.x, 0.25f * scr.y), inv[i].Name))
                    {
                        selectedItem = inv[i];
                    }
                }

                // End 

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
                    break;
                case ItemType.Weapon:
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
            if (GUI.Button(new Rect(scr.x, scr.y, scr.x, scr.y), "Discard"))
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
            }
        }
    }
}
