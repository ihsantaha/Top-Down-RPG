using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialog : MonoBehaviour
{
    /*
    public struct DialogTextSetX
    {
        public string dialogText;
        public bool isDecisionPoint, isEndPoint;

        public void SetDialogInfo(string str)
        {
            dialogText = str;
        }

        public void SetDialogInfo(string str, bool dec)
        {
            dialogText = str;
            isDecisionPoint = dec;
        }

        public void SetDialogInfo(string str, bool dec, bool end)
        {
            dialogText = str;
            isDecisionPoint = dec;
            isEndPoint = end;
        }
    }
 
    public DialogTextSetX[] dialogTextSetList;
    */

    public DialogTextSet[] dialogTextSetList;
    public Text textComponent;

    void Start()
    {
        /*
        dialogTextSetList = new DialogTextSetX[7];
        dialogTextSetList[0].SetDialogInfo("Sample Dialog 1: Hello, this is a test on the game's dialog, press N to continue to the next sentence.");
        dialogTextSetList[1].SetDialogInfo("This is the second piece in the dialog, the meat of the conversation, press N again to continue once more.");
        dialogTextSetList[2].SetDialogInfo("This is a decision point, choose a path to get to a different ending. Press N to continue or O for other choice.", true, false);
        dialogTextSetList[3].SetDialogInfo("This is path one. Now press N to continue to ending one.");
        dialogTextSetList[4].SetDialogInfo("This is ending one. Now press N to end the conversation, or press C at anytime to cancel if the dialog is cancellable.", false, true);
        dialogTextSetList[5].SetDialogInfo("This is path two. Now press N to continue to ending two.", false, false);
        dialogTextSetList[6].SetDialogInfo("This is ending two. Press C at anytime to cancel if the dialog is cancellable.", false, true
        
        dialogTextSetListX = GetComponent<DialogTextSet>().GetNextDialogTextSetList();
        */
    }
}
