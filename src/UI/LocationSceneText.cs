using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MBUnity
{
    public class LocationSceneText : MonoBehaviour
    {

        private Text m_text;

        private LocationSceneUI m_locationSceneUI;
        // Use this for initialization

        private void Awake()
        {
            m_text = GetComponent<Text>();
            m_locationSceneUI = GetComponentInParent<LocationSceneUI>();
        }

        // Update is called once per frame
        void OnEnable()
        {
            m_text.text = "You are in " + m_locationSceneUI.locationData.Name + ". ";
            m_text.text += "Ruler of this city is " + m_locationSceneUI.locationData.Ruler.Name;
        }
    }

}