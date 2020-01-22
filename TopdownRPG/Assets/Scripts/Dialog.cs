using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialog : MonoBehaviour
{
    public Text textComponent;
    public DynamicText startingDialog;
    public DynamicText currentDialog;
    int currentDialogIndex;

    public GameObject player;
    public GameObject dialogLoader;

    void Start()
    {
        currentDialog = startingDialog;
        currentDialogIndex = 0;
        player = GameObject.FindGameObjectWithTag("Player");
        dialogLoader = GameObject.FindGameObjectWithTag("DialogLoader");
    }

    void Update()
    {
        ManageCurrentDialog();
    }

    public void ManageCurrentDialog()
    {
        var nextDynamicTexts = currentDialog.GetNextDynamicTexts();
        if (player.GetComponent<PlayerCollision>().nearBed && dialogLoader.GetComponent<DialogLoader>().currentStateIsOpen && Input.GetKeyDown(KeyCode.X))
        {
            if (currentDialogIndex != nextDynamicTexts.Length - 2)
            {
                currentDialog = nextDynamicTexts[currentDialogIndex];
                textComponent.text = currentDialog.GetDialog();
                currentDialogIndex += 1;
            }
            else
            {
                currentDialogIndex = 0;
                currentDialog = nextDynamicTexts[0];
                textComponent.text = currentDialog.GetDialog();
            }
        }
    }
}
