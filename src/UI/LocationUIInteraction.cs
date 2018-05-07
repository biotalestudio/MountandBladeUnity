using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MBUnity
{
    public class LocationUIInteraction : MonoBehaviour
    {
        public static bool IsOverOnLocation;

        public Location locationData;

        private LocationUI m_locationUI;
        private Camera m_mainCamera;

        // Use this for initialization
        void Start()
        {
            m_locationUI = GameObject.FindGameObjectWithTag("LocationUI").GetComponent<LocationUI>();
            m_mainCamera = Camera.main;
            locationData = GetComponentInParent<LocationSetup>().LocationData;
        }

        private void OnMouseEnter()
        {
            LocationUI.LocationData = locationData;
            m_locationUI.Activate();
            m_locationUI.transform.position = m_mainCamera.WorldToScreenPoint(transform.position);
            IsOverOnLocation = true;
        }

        private void OnMouseOver()
        {
            m_locationUI.transform.position = m_mainCamera.WorldToScreenPoint(transform.position);
        }

        private void OnMouseExit()
        {
            m_locationUI.Deactivate();
            IsOverOnLocation = false;
        }

        // Update is called once per frame
        void Update()
        {

        }
    }

}