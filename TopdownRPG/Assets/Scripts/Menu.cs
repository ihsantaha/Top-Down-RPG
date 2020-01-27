using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public SceneLoader sceneLoader;

    public GameObject stats, inventory, skills, options, returnTab;
    public bool onStatsTab, onInventoryTab, onSkillsTab, onOptionsTab, onReturnTab;

    void Start()
    {
        sceneLoader = GetComponent<SceneLoader>();
        stats = GameObject.FindGameObjectWithTag("StatsSubMenu");
        inventory = GameObject.FindGameObjectWithTag("InventorySubMenu");
        skills = GameObject.FindGameObjectWithTag("SkillsSubMenu");
        options = GameObject.FindGameObjectWithTag("OptionsSubMenu");
        returnTab = GameObject.FindGameObjectWithTag("ReturnTab");

        onStatsTab = true;
    }

    void Update()
    {
        returnFromMenu();
        checkControllerInput();
        updateUI();
    }

    public void returnFromMenu()
    {
        if (Input.GetKeyDown(KeyCode.C) && StaticClass.CurrentScene > 3)
        {
            StaticClass.PreviousScene = StaticClass.CurrentScene;
            sceneLoader.NavigateFrom(3);
        }
    }


    public void checkControllerInput()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (onStatsTab)
            {
                onStatsTab = false;
                onInventoryTab = true;
            } else if(onInventoryTab)
            {
                onInventoryTab = false;
                onSkillsTab = true;
            } else if (onSkillsTab)
            {
                onSkillsTab = false;
                onOptionsTab = true;
            } else if (onOptionsTab)
            {
                onOptionsTab = false;
                onReturnTab = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (onInventoryTab)
            {
                onInventoryTab = false;
                onStatsTab = true;
            }
            else if (onSkillsTab)
            {
                onSkillsTab = false;
                onInventoryTab = true;
            }
            else if (onOptionsTab)
            {
                onOptionsTab = false;
                onSkillsTab = true;
            } else if (onReturnTab)
            {
                onReturnTab = false;
                onOptionsTab = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.Return) || Input.GetAxisRaw("Fire1 Xbox") == 0)
        {
            if (onStatsTab)
                print("On Stats Tab");
            if (onInventoryTab)
                print("On Inventory Tab");
            if (onSkillsTab)
                print("On Skills Tab");
            if (onOptionsTab)
            {   
                sceneLoader.LoadSpecificScene(1);
            }
            if (onReturnTab)
                sceneLoader.CloseMenu();
        }
    }

    public void updateUI()
    {
        if (onStatsTab)
            stats.GetComponent<Button>().Select();
        if (onInventoryTab)
            inventory.GetComponent<Button>().Select();
        if (onSkillsTab)
            skills.GetComponent<Button>().Select();
        if (onOptionsTab)
            options.GetComponent<Button>().Select();
        if (onReturnTab)
            returnTab.GetComponent<Button>().Select();
    }
}
