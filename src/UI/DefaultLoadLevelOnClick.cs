using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DefaultLoadLevelOnClick : MonoBehaviour {
    
    public void LoadLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

}
