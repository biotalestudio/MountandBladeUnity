using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MBUnity
{
    public class RecruitVolunteersButtonLogic : MonoBehaviour
    {
        public int priortyValue;

        private LocationSceneUI m_locationSceneUI;

        private Button m_button;
        private Image m_image;
        private Text m_text;

        void Awake()
        {
            m_locationSceneUI = GetComponentInParent<LocationSceneUI>();
            m_image = GetComponent<Image>();
            m_button = GetComponent<Button>();
            m_text = GetComponentInChildren<Text>();

            m_text.enabled = false;
            m_image.enabled = false;
            m_button.enabled = false;

            Debug.Log("Awake");
        }

        private void OnEnable()
        {
            if (CheckForAvailability())
            {

            }

        }

        bool CheckForAvailability()
        {
            if (m_locationSceneUI.locationData.Type == Enums.LocationType.Village && false)
            {
                return true;
            }
            else
                return false;
        }

        public void ActivateButton()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    } 
}
