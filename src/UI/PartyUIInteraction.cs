using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEditor;

namespace MBUnity
{
    public class PartyUIInteraction : MonoBehaviour
    {
        public static bool IsOverOnParty;

        public Party partyData;

        public bool isFollowingParty;

        public GameObject partySizeText;

        private TextMesh m_sizeText;
        private GameObject m_horseObject;

        private PartyUI m_partyUI;
        private RectTransform m_partyRect;
        private Camera m_mainCamera;
        private GameObject deneme;

        // Use this for initialization
        void Start()
        {
            //m_horseObject = (GameObject)AssetDatabase.LoadAssetAtPath("Assets/Prefabs/Horse.prefab", typeof(GameObject));
            m_sizeText = partySizeText.GetComponent<TextMesh>();
            m_partyUI = GameObject.FindGameObjectWithTag("PartyUI").GetComponent<PartyUI>();
            m_partyRect = m_partyUI.GetComponent<RectTransform>();
            m_mainCamera = Camera.main;
        }

        void OnMouseEnter()
        {
            PartyUI.partyData = partyData;
            m_partyUI.Activate();
            m_partyUI.transform.position = m_mainCamera.WorldToScreenPoint(transform.position);
            IsOverOnParty = true;
            partySizeText.SetActive(false);
        }

        private void OnMouseOver()
        {
            m_partyUI.transform.position = Camera.main.WorldToScreenPoint(transform.position);
        }

        private void OnMouseExit()
        {
            IsOverOnParty = false;
            PartyUI.partyData = null;
            m_partyUI.Deactivate();
            partySizeText.SetActive(true);
        }

        void Update()
        {
            m_sizeText.text = partyData.Size.ToString();
        }
    }

}