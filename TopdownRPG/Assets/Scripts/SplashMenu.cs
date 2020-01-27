using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SplashMenu : MonoBehaviour
{
    public SceneLoader sceneLoader;
    public GameObject start, options, quit;
    public bool onStartButton, onOptionsButton, onQuitButton;
    public bool clickedDown, clickedUp, fromFrontDoor, fromBackDoor;

    void Start()
    {
        sceneLoader = GetComponent<SceneLoader>();
        start = GameObject.FindGameObjectWithTag("StartButton");
        options = GameObject.FindGameObjectWithTag("OptionsSubMenu");
        quit = GameObject.FindGameObjectWithTag("QuitButton");
        fromFrontDoor = true;
        fromBackDoor = true;
    }

    void Update()
    {
        CheckControllerInput();
        UpdateUI();
        // CoolDownAxix();
    }

    public void CheckControllerInput()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow) || (Input.GetAxisRaw("Vertical Xbox") < 0 && !clickedDown))
        {

            if (fromBackDoor)
            {
                StartCoroutine(Axis("down"));
                fromBackDoor = false;
                onStartButton = true;
            }
            else if (onStartButton)
            {
                StartCoroutine(Axis("down"));
                onStartButton = false;
                onOptionsButton = true;
            }
            else if (onOptionsButton)
            {
                StartCoroutine(Axis("down"));
                onOptionsButton = false;
                onQuitButton = true;
            } else if (onQuitButton)
            {
                StartCoroutine(Axis("down"));
                onQuitButton = false;
                onStartButton = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) || (Input.GetAxisRaw("Vertical Xbox") > 0 && !clickedUp))
        {
            if (onStartButton)
            {
                StartCoroutine(Axis("up"));
                onStartButton = false;
                onQuitButton = true;
            }
            else if (onOptionsButton)
            {
                StartCoroutine(Axis("up"));
                onStartButton = true;
                onOptionsButton = false;
            }
            else if (onQuitButton)
            {
                StartCoroutine(Axis("up"));
                onOptionsButton = true;
                onQuitButton = false;
            }
            else if (fromBackDoor)
            {
                StartCoroutine(Axis("up"));
                fromBackDoor = false;
                onQuitButton = true;
            }
        }

        /*
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetAxisRaw("Fire1 Xbox") == 0)
        {
            if (onStartButton)
                print("On Start Button");
            if (onOptionsButton)
                print("On Options Button");
            if (onQuitButton)
                print("On Quit Button");
        }
        */
    }

    public void UpdateUI()
    {
        if (onStartButton)
            start.GetComponent<Button>().Select();
        if (onOptionsButton)
            options.GetComponent<Button>().Select();
        if (onQuitButton)
            quit.GetComponent<Button>().Select();
    }

    public void CoolDownAxix() 
    {
        if (Input.GetAxisRaw("Vertical Xbox") > 0)
            StartCoroutine(Axis("up"));
        if (Input.GetAxisRaw("Vertical Xbox") < 0)
            StartCoroutine(Axis("down"));
    }

    public IEnumerator Axis(string direction)
    {
        if (direction == "up")
        {
            clickedUp = true;
            yield return new WaitForSeconds(0.2f);
            clickedUp = false;
        }
        if (direction == "down")
        {
            clickedDown = true;
            yield return new WaitForSeconds(0.2f);
            clickedDown = false;
        }
    }
}
