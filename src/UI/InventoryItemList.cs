using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MBUnity
{
    public class InventoryItemList : MonoBehaviour
    {
        public GameObject itemPanel;
        public bool isSeller;

        [SerializeField]
        private List<Item> m_ItemList;

        void Awake()
        {
            if (isSeller)
                m_ItemList = GetComponentInParent<InventoryUI>().sellerData.Inventory;
            else
                m_ItemList = GetComponentInParent<InventoryUI>().characterData.Inventory;

            int counter = 0;
            foreach (Item item in m_ItemList)
            {
                GameObject panel = Instantiate(itemPanel);
                panel.transform.SetParent(gameObject.transform);
                panel.GetComponent<InventoryItemPanel>().itemData = item;
                RectTransform rect = panel.GetComponent<RectTransform>();
                rect.anchoredPosition = new Vector2(125, -55 + (-35 * counter));
                rect.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                Debug.Log(rect.position);
                counter++;
            }
            counter = 0;
        }

    }
}