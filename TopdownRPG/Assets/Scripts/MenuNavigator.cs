using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuNavigator : MonoBehaviour
{
    public GameObject stats;
    public GameObject options;
    public GameObject menuControllerHandler;

    void Start()
    {
        stats = GameObject.FindGameObjectWithTag("Stats");
        options = GameObject.FindGameObjectWithTag("OptionsSubMenu");
        menuControllerHandler = GameObject.FindGameObjectWithTag("MenuControllerHandler");
    }

    void Update()
    {
        var menuController = menuControllerHandler.GetComponent<MenuControllerHandler>();

        if (menuController.menuItemSelected[0])
            stats.SetActive(true);
        else
            stats.SetActive(false);
    }
}
