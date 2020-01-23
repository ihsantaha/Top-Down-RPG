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

    public void OpenMenu()
    {
        StaticClass.CurrentPosition = player.transform.position;
        print(StaticClass.CurrentPosition);
        SceneManager.LoadSceneAsync(3);
    }
}
