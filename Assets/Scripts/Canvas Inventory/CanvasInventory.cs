using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasInventory : MonoBehaviour
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

    [Header("References")]
    public GameObject inventoryPanel;

    [System.Serializable]
    public struct equipment
    {
        public string name;
        public Transform location;
        public GameObject curItem;
    };
    public equipment[] equipmentSlots;
    #endregion

    public ScrollRect view;
    public GameObject invButton;
    public RectTransform content;

    public Button[] topSlots;
    public GameObject[] leftButtons;

    private void Start()
    {
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        inventoryPanel.SetActive(false);

        inv.Add(ItemData.CreateItem(0));
        inv.Add(ItemData.CreateItem(1));
        inv.Add(ItemData.CreateItem(2));
        inv.Add(ItemData.CreateItem(81));
        inv.Add(ItemData.CreateItem(61));

        for (int i = 0; i < inv.Count; i++)
        {
            leftButtons[i] = Instantiate(invButton, content);
            leftButtons[i].GetComponentInChildren<Text>().text = inv[i].Name;
        }
    }

    private void Update()
    {
        content.sizeDelta = new Vector2(0, 30f * inv.Count);

        if (Input.GetKey(KeyCode.I))
        {
            inv.Add(ItemData.CreateItem(Random.Range(0, 5)));

            for (int i = 0; i < inv.Count; i++)
            {
                leftButtons[i] = Instantiate(invButton, content);
                leftButtons[i].GetComponentInChildren<Text>().text = inv[i].Name;
            }
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
                inventoryPanel.SetActive(true);
                return;
            }
            else
            {
                Time.timeScale = 1;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                inventoryPanel.SetActive(false);
                return;
            }
        }
        TopMenuControl();
    }

    void TopMenuControl()
    {
        if(sortType == ItemType.All)
        {
            for (int i = 0; i < leftButtons.Length; i++)
            {
                leftButtons[i].SetActive(true);
            }
        }
        else
        {
            for (int i = 0; i < leftButtons.Length; i++)
            {
                leftButtons[i].SetActive(false);
                for (int a = 0; a < (int)ItemType.All - 1; a++)
                {
                    sortType = (ItemType)a;
                    if (topSlots[i].name.ToString() == sortType.ToString())
                    {
                        leftButtons[i].SetActive(true);
                    }
                }
            }

        }
    }

    void Boom()
    {
        for (int i = 1; i < topSlots.Length; i++)
        {
            for (int a = 0; a < (int)ItemType.All - 1; a++)
            {
                sortType = (ItemType)a;
            }
        }
    }
}
