using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public SceneLoader sceneLoader;
    public GameObject stats, inventory, skills, options, returnTab;
    public bool onStatsTab, onInventoryTab, onSkillsTab, onOptionsTab, onReturnTab, fromFrontDoor, fromBackDoor;
    public bool clickedLeft, clickedRight;

    void Start()
    {
        sceneLoader = GetComponent<SceneLoader>();
        stats = GameObject.FindGameObjectWithTag("StatsSubMenu");
        inventory = GameObject.FindGameObjectWithTag("InventorySubMenu");
        skills = GameObject.FindGameObjectWithTag("SkillsSubMenu");
        options = GameObject.FindGameObjectWithTag("OptionsSubMenu");
        returnTab = GameObject.FindGameObjectWithTag("ReturnTab");
        fromFrontDoor = true;
        fromBackDoor = true;
    }

    void Update()
    {
        ReturnFromMenu();
        CheckControllerInput();
        UpdateUI();
        // CoolDownAxix();
    }

    public void ReturnFromMenu()
    {
        if (Input.GetButtonDown("B Button") && StaticClass.CurrentScene > 3)
        {
            StaticClass.PreviousScene = StaticClass.CurrentScene;
            sceneLoader.NavigateFrom(3);
        }
    }


    public void CheckControllerInput()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow) || (Input.GetAxisRaw("Horizontal Xbox") > 0 && !clickedRight))
        {
            if (fromFrontDoor)
            {
                fromFrontDoor = false;
                onStatsTab = true;
                StartCoroutine(Axis("right"));
            }
            else if (onStatsTab)
            {
                onStatsTab = false;
                onInventoryTab = true;
                StartCoroutine(Axis("right"));
            }
            else if (onInventoryTab)
            {
                onInventoryTab = false;
                onSkillsTab = true;
                StartCoroutine(Axis("right"));
            }
            else if (onSkillsTab)
            {
                onSkillsTab = false;
                onOptionsTab = true;
                StartCoroutine(Axis("right"));
            }
            else if (onOptionsTab)
            {
                onOptionsTab = false;
                onReturnTab = true;
                StartCoroutine(Axis("right"));
            }
            else if (onReturnTab)
            {
                onReturnTab = false;
                onStatsTab = true;
                StartCoroutine(Axis("right"));
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow) || (Input.GetAxisRaw("Horizontal Xbox") < 0 && !clickedLeft))
        {
            if (onStatsTab)
            {
                onStatsTab = false;
                onReturnTab = true;
                StartCoroutine(Axis("left"));
            }
            else if (onInventoryTab)
            {
                onStatsTab = true;
                onInventoryTab = false;
                StartCoroutine(Axis("left"));
            }
            else if (onSkillsTab)
            {
                onInventoryTab = true;
                onSkillsTab = false;
                StartCoroutine(Axis("left"));
            }
            else if (onOptionsTab)
            {
                onSkillsTab = true;
                onOptionsTab = false;
                StartCoroutine(Axis("left"));
            }
            else if (onReturnTab)
            {
                onOptionsTab = true;
                onReturnTab = false;
                StartCoroutine(Axis("left"));
            }
            else if (fromBackDoor)
            {
                fromBackDoor = false;
                onReturnTab = true;
                StartCoroutine(Axis("left"));
            }
        }

        /*
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
        */
    }

    public void UpdateUI()
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

    public void CoolDownAxix()
    {
        if (Input.GetAxisRaw("Horizontal Xbox") > 0)
            StartCoroutine(Axis("right"));
        else if (Input.GetAxisRaw("Horizontal Xbox") < 0)
            StartCoroutine(Axis("left"));
    }


    public IEnumerator Axis(string direction)
    {
        if (direction == "right")
            clickedRight = true;
        else if (direction == "left")
            clickedLeft = true;

        yield return new WaitForSeconds(0.2f);

        if (direction == "right")
            clickedRight = false;
        else if (direction == "left")
            clickedLeft = false;
    }
}
