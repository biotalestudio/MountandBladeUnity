using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MBUnity
{
    public class InventoryItemImage : MonoBehaviour
    {
        [SerializeField]
        private Item m_ItemData;

        private Image m_Image;

        void Start()
        {
            m_Image = GetComponent<Image>();

            m_ItemData = GetComponentInParent<InventoryItemPanel>().itemData;

            m_Image.sprite = m_ItemData.Sprite;
        }
    } 
}
