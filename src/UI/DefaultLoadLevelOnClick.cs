using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MBUnity
{
    public class DefaultLoadLevelOnClick : MonoBehaviour
    {

        public void LoadLevel(string levelName)
        {
            SceneManager.LoadScene(levelName);
        }

    }

}