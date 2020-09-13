using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuNavigator : MonoBehaviour
{
    public GameObject stats;
    public GameObject skills;
    public GameObject options;
    public GameObject menuControllerHandler;

    void Start()
    {
        stats = GameObject.FindGameObjectWithTag("Stats");
        skills = GameObject.FindGameObjectWithTag("Skills");
        options = GameObject.FindGameObjectWithTag("OptionsSubMenu");
        menuControllerHandler = GameObject.FindGameObjectWithTag("MenuControllerHandler");
    }

    void Update()
    {
        var menuController = menuControllerHandler.GetComponent<MenuControllerHandler>();

        if (menuController.menuItemSelected[0] || StaticClass.statsSelected)
            stats.SetActive(true);
        else
            stats.SetActive(false);

        if (menuController.menuItemSelected[2] || StaticClass.skillsSelected)
            skills.SetActive(true);
        else
            skills.SetActive(false);
    }
}
