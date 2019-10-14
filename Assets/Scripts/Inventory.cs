using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Linear
{
    public class Inventory : MonoBehaviour
    {
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
            inv.Add(ItemData.CreateItem(0));
        }

        private void Update()
        {
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
            }
        }
    }
}
