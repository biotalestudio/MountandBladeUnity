using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MBUnity
{
    public class PartTextCameraInteraction : MonoBehaviour
    { 
        private GameObject m_mainCamera;
        private Party m_party;
        private TextMesh m_text;

        // Use this for initialization
        void Start()
        {
            m_mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
            m_text = GetComponent<TextMesh>();
            m_party = GetComponentInParent<PartyScript>().GetParty();
        }

        // Update is called once per frame
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

            m_text.color = m_party.Leader.FactionData.Color;
            Vector3 textRot = transform.rotation.eulerAngles;
            Vector3 rotDir = new Vector3(m_mainCamera.transform.rotation.eulerAngles.x, m_mainCamera.transform.rotation.eulerAngles.y, textRot.z);
            transform.rotation = Quaternion.Euler(rotDir);
        }
    } 
}
