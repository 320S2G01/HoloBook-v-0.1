using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Scenes : MonoBehaviour {

    private void Start()
    {
        DontDestroyOnLoad(this);
    }

    public void ChangeScene(string sceneName) {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
        DontDestroyOnLoad(this);
    }
}