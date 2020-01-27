using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public SceneLoader sceneLoader;

    void Start()
    {
        sceneLoader = GetComponent<SceneLoader>();
    }

    void Update()
    {
        ReturnFromMenu();
    }

    public void ReturnFromMenu()
    {
        if (Input.GetButtonDown("B Button") && StaticClass.CurrentScene > 3)
        {
            StaticClass.PreviousScene = StaticClass.CurrentScene;
            sceneLoader.NavigateFrom(3);
        }
    }
}
