using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    public SceneLoader sceneLoader;
    public bool nearBed;
    public bool attemptToSleep;
    public int dialogSetNumber;

    void Start()
    {
        sceneLoader = GetComponent<SceneLoader>();
    }

    void Update()
    {
        Sleep();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        var obj = collision.gameObject.tag;

        if (obj == "Item")
            Destroy(collision.gameObject);
        if (obj == "BadObject")
            SceneManager.LoadSceneAsync(2);
        if (obj == "Bed")
            nearBed = true;
        if (obj == "Exit")
        {
            StaticClass.PreviousScene = StaticClass.CurrentScene;
            sceneLoader.NavigateFrom(collision.gameObject.GetComponent<Exit>().exitNumber);
        }
    }

    public void Sleep()
    {
        if (nearBed && Input.GetKeyDown(KeyCode.X))
        {
            nearBed = false;
            attemptToSleep = true;
            dialogSetNumber = 0;
        }
    }
}
