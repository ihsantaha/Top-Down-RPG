using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialog : MonoBehaviour
{
    public String[] dialogTextSet;
    public Text textComponent;

    void Start()
    {
        dialogTextSet = new string[5];
        dialogTextSet[0] = "Sample Dialog 1: Hello, this is a test on the game's dialog, press N to continue to the next sentence.";
        dialogTextSet[1] = "This is the second piece in the dialog, the meat of the conversation, press N again to continue once more.";
        dialogTextSet[2] = "This is a decision point, choose a path to get to a different ending. Press F for the first choice, and S for the second.";
        dialogTextSet[3] = "This is ending one. Now press N to end the conversation, or press C at anytime to cancel if the dialog is cancellable.";
        dialogTextSet[4] = "This is ending two. Press C at anytime to cancel if the dialog is cancellable.";
    }
}
