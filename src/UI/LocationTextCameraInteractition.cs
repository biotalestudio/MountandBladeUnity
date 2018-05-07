using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MBUnity
{
    public class LocationTextCameraInteractition : MonoBehaviour
    {
        public int minTextSize = 25;

        TextMesh m_text;
        GameObject m_mainCamera;
        CameraMovement m_cameraMovement;
        Location m_locationData;

        bool HasFontChanged = false;
        bool isDistanceChanged = true;

        private Vector4 factionColor;

        void Start()
        {
            m_text = GetComponent<TextMesh>();
            m_mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
            m_cameraMovement = m_mainCamera.GetComponent<CameraMovement>();
            m_locationData = GetComponentInParent<LocationSetup>().LocationData;
            factionColor = m_locationData.Ruler.FactionData.Color;
        }

        void Update()
        {
            Vector3 rayDirection = m_mainCamera.transform.position - transform.position;
            Debug.DrawRay(transform.position, rayDirection);
            RaycastHit info;

            //Needs some optimization
            if (Physics.Raycast(transform.position, rayDirection, out info, 1000f))
            {
                if (info.collider.tag == "Terrain")
                {
                    m_text.color = new Vector4(0f, 0f, 0f, 0f);
                    return;
                }
            }

            Vector3 textRot = transform.rotation.eulerAngles;
            Vector3 rotDir = new Vector3(m_mainCamera.transform.rotation.eulerAngles.x, m_mainCamera.transform.rotation.eulerAngles.y, textRot.z);
            transform.rotation = Quaternion.Euler(rotDir);
            m_text.color = factionColor;

            if (m_locationData.Type == Enums.LocationType.City)
            {
                m_text.fontSize = (int)(m_mainCamera.transform.position.y - transform.position.y);
                if (m_text.fontSize <= 25)
                    m_text.fontSize = minTextSize;
            }
        }
    }

}