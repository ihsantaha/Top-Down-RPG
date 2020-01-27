using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuControllerHandler : MonoBehaviour
{
    public GameObject[] menuGameObjects;
    public bool horizontal;
    bool[] menuItemSelected;
    bool clickedNegative, clickedPositive, fromFrontDoor, fromBackDoor;
    bool positiveMovement, negativeMovement;
    float horizontalInput, verticalInput;

    void Start()
    {
        fromFrontDoor = true;
        fromBackDoor = true;
        menuItemSelected = new bool[menuGameObjects.Length];
    }

    void Update()
    {
        CheckControllerInput();
        UpdateUI();
    }

    public void CheckControllerInput()
    {
        if (horizontal)
        {
            horizontalInput = Input.GetAxisRaw("Horizontal Xbox");
            positiveMovement = Input.GetKeyDown(KeyCode.RightArrow);
            negativeMovement = Input.GetKeyDown(KeyCode.LeftArrow);
        }
        else
        {
            verticalInput = Input.GetAxisRaw("Vertical Xbox");
            positiveMovement = Input.GetKeyDown(KeyCode.DownArrow);
            negativeMovement = Input.GetKeyDown(KeyCode.UpArrow);
        }

        if (positiveMovement || ((horizontalInput > 0 || verticalInput < 0) && !clickedPositive))
        {
            if (fromFrontDoor)
            {
                StartCoroutine(Axis("positive"));
                fromFrontDoor = false;
                menuItemSelected[0] = true;
            }
            else
            {
                for (int i = 0; i < menuGameObjects.Length; i++)
                {
                    if (menuItemSelected[i])
                    {
                        StartCoroutine(Axis("positive"));
                        menuItemSelected[i] = false;

                        if (i < menuGameObjects.Length - 1)
                            menuItemSelected[i + 1] = true;
                        else
                            menuItemSelected[0] = true;

                        break;
                    }
                }
            }
        }

        if (negativeMovement || ((horizontalInput < 0 || verticalInput > 0) && !clickedNegative))
        {
            if (fromBackDoor)
            {
                StartCoroutine(Axis("negative"));
                fromBackDoor = false;
                menuItemSelected[menuGameObjects.Length - 1] = true;
            }
            else
            {
                for (int i = menuGameObjects.Length-1; i >= 0; i--)
                {
                    if (menuItemSelected[i])
                    {
                        StartCoroutine(Axis("negative"));
                        menuItemSelected[i] = false;

                        if (i > 0)
                            menuItemSelected[i - 1] = true;
                        else
                            menuItemSelected[menuGameObjects.Length - 1] = true;

                        break;
                    }
                }
            }
        }
    }
    
    public void UpdateUI()
    {
        for (int i = 0; i < menuItemSelected.Length; i++)
            if (menuItemSelected[i])
                menuGameObjects[i].GetComponent<Button>().Select();
    }

    public IEnumerator Axis(string direction)
    {
        if (direction == "positive")
        {
            clickedPositive = true;
            yield return new WaitForSeconds(0.2f);
            clickedPositive = false;
        }
        if (direction == "negative")
        {
            clickedNegative = true;
            yield return new WaitForSeconds(0.2f);
            clickedNegative = false;
        }
    }
}

