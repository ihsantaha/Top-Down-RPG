using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
    public GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        StaticClass.CurrentScene = SceneManager.GetActiveScene().buildIndex;
    }

    void Update()
    {
        OpenMenuFromKey();
    }

    public void OpenMenu()
    {
        StaticClass.CurrentPosition = player.transform.position;
        SceneManager.LoadSceneAsync(3);
    }

    public void OpenMenuFromKey()
    {
        StaticClass.CurrentPosition = player.transform.position;
        if (Input.GetKeyDown(KeyCode.M))
            SceneManager.LoadSceneAsync(3);
    }
}
