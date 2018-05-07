using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MBUnity
{
    public class PartySizeColor : MonoBehaviour
    {
        private Party m_partyData;
        private TextMesh m_text;

        // Use this for initialization
        void Start()
        {
            m_partyData = GetComponentInParent<PartyUIInteraction>().partyData;
            m_text = GetComponent<TextMesh>();
            m_text.color = m_partyData.Leader.FactionData.Color;
        }
    }

}