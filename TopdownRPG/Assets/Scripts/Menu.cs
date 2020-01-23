using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public SceneLoader sceneLoader;
    
    void Start()
    {
        sceneLoader = GetComponent<SceneLoader>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C) && StaticClass.CurrentScene > 3)
        {
            StaticClass.PreviousScene = StaticClass.CurrentScene;
            sceneLoader.NavigateFrom(3);
        }
    }
}
