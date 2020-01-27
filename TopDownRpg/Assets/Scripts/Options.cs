using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Options : MonoBehaviour {

    public void Update()
    {
        returnFromOptions();
    }

    public void returnFromOptions()
    {

        if (Input.GetButtonDown("B Button")) {
            if (StaticClass.CurrentScene > 3)
                SceneManager.LoadSceneAsync(3);
            else
                SceneManager.LoadSceneAsync(0);
        }
    }
      
}
