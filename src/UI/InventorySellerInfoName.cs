using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MBUnity
{
    public class InventorySellerInfoName : MonoBehaviour
    {
        private Character m_SellerData;
        private Text m_Text;

        void Start()
        {
            m_SellerData = GetComponentInParent<InventoryUI>().sellerData;
            m_Text = GetComponent<Text>();

            m_Text.text = m_SellerData.Name;
        }

    }
}
