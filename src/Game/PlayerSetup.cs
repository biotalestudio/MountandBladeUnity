using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MBUnity
{
    public class PlayerSetup : MonoBehaviour
    {

        private void Awake()
        {
            //DontDestroyOnLoad(gameObject);
            GameObject obj = GameObject.FindGameObjectWithTag("Player");
        }

        private void Update()
        {

        }

    } 
}
