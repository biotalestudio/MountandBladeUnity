using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MBUnity
{
    public class GoVillageCenterLogic : MonoBehaviour
    {
        private LocationSceneUI m_locationSceneUI;

        void OnEnable()
        {
            m_locationSceneUI = GameObject.FindGameObjectWithTag("LocationSceneUI").GetComponent<LocationSceneUI>();
        }

        public void GoToVillage()
        {
            SceneManager.LoadScene(m_locationSceneUI.locationData.sceneName);
        }

    }

}