using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationTextCameraInteractition : MonoBehaviour {

    public int minTextSize = 25;

    TextMesh m_text;
    GameObject m_mainCamera;
    CameraMovement m_cameraMovement;
    Location m_locationData;

    bool HasFontChanged = false;
    bool isDistanceChanged = true;

	// Use this for initialization
	void Start ()
    {
        m_text = GetComponent<TextMesh>();
        m_mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        m_cameraMovement = m_mainCamera.GetComponent<CameraMovement>();
        m_locationData = GetComponentInParent<LocationSetup>().LocationData;
	}
	
	// Update is called once per frame
	void Update ()
    {
        Vector3 textRot = transform.rotation.eulerAngles;
        Vector3 rotDir = new Vector3(m_mainCamera.transform.rotation.eulerAngles.x, m_mainCamera.transform.rotation.eulerAngles.y, textRot.z);
        transform.rotation = Quaternion.Euler(rotDir);


        if(m_locationData.Type == Enums.LocationType.City)
        {
            m_text.fontSize = (int)(m_mainCamera.transform.position.y - transform.position.y);
            if (m_text.fontSize <= 25)
                m_text.fontSize = minTextSize;
        }
	}
}
