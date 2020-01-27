using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogLoader : MonoBehaviour
{
    public GameObject player;
    public GameObject dialogBox;
    public GameObject dialog;
    public bool activate;
    public bool currentStateIsOpen;
    public bool decisionPoint;
    int currentDialogTextIndex;
    int objectID;
    int decisionPointID;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        dialogBox = GameObject.FindGameObjectWithTag("DialogBox");
        dialogBox.GetComponent<Transform>().position = new Vector3(1000, -3, 0);
        objectID = GetComponent<ObjectID>().ID;
    }

    void Update()
    {
        IsOpenable();
        OpenDialog(objectID, decisionPointID);
        ManageDialog();
    }

    public bool IsOpenable()
    {
        RaycastHit2D playerHitFromLeft = Physics2D.Raycast(transform.position, Vector2.left, 0.55f, 1 << 8);
        RaycastHit2D playerHitFromTop = Physics2D.Raycast(transform.position, Vector2.up, 0.55f, 1 << 8);
        RaycastHit2D playerHitFromRight = Physics2D.Raycast(transform.position, Vector2.right, 0.55f, 1 << 8);
        RaycastHit2D playerHitFromBottom = Physics2D.Raycast(transform.position, Vector2.left, 0.55f, 1 << 8);

        return (playerHitFromLeft.collider != null || playerHitFromTop.collider != null || playerHitFromRight.collider != null || playerHitFromBottom.collider != null) ? true : false;
    }

    /*
    public void OpenDialog(int objectID)
    {
        var dialogTextSet = dialog.GetComponent<Dialog>().dialogTextSetList[getDialog(objectID)];

        if (IsOpenable() && !currentStateIsOpen && Input.GetKeyDown(KeyCode.X))
        {
            currentStateIsOpen = true;
            currentDialogTextIndex = getDialog(objectID);    
            dialogBox.GetComponent<Transform>().position = Vector2.zero;
            Instantiate(dialog, Vector3.zero, transform.rotation);
            player.GetComponent<PlayerMovement>().moveSpeed = 0;
            dialog.GetComponent<Dialog>().textComponent.text = dialogTextSet.dialogText;
        }
    }
    */

    public void OpenDialog(int objID, int decPointID)
    {
        var dialogTextSet = dialog.GetComponent<Dialog>().dialogTextSetList[getDialog(objID,decPointID)];

        if (IsOpenable() && !currentStateIsOpen && Input.GetKeyDown(KeyCode.X))
        {
            currentStateIsOpen = true;
            currentDialogTextIndex = getDialog(objectID, decPointID);

            if (decisionPointID == 0)
            {
                player.GetComponent<PlayerMovement>().moveSpeed = 0;
                dialogBox.GetComponent<Transform>().position = new Vector3(0, -3.5f, 0);
                Instantiate(dialog, Vector3.zero, transform.rotation);
            }

            dialog.GetComponent<Dialog>().textComponent.text = dialogTextSet.dialogText;
        }
    }

    public void ManageDialog()
    {
        var dialogTextSetList = dialog.GetComponent<Dialog>().dialogTextSetList;

        if (currentStateIsOpen)
        {
            if (dialogTextSetList[currentDialogTextIndex].isEndPoint && Input.GetKeyDown(KeyCode.N))
            {
                CloseDialog();
            }
            else if (dialogTextSetList[currentDialogTextIndex].isDecisionPoint && Input.GetKeyDown(KeyCode.O))
            {
                /***/
                dialog.GetComponent<Dialog>().textComponent.text = dialogTextSetList[getDialog(objectID, currentDialogTextIndex)].dialogText;
                currentDialogTextIndex = getDialog(objectID, currentDialogTextIndex);
                
                /***/
                //dialog.GetComponent<Dialog>().textComponent.text = dialogTextSetList[getDialog(currentDialogTextIndex)].dialogText; // 1- Get the corresponding dialog text set
                //currentDialogTextIndex = getDialog(currentDialogTextIndex); // 2- Reset
            }
            else if (Input.GetKeyDown(KeyCode.N))
            {
                currentDialogTextIndex++;
                dialog.GetComponent<Dialog>().textComponent.text = dialogTextSetList[currentDialogTextIndex].dialogText;
            }
        }
    }

    public void CloseDialog()
    {
        currentStateIsOpen = false;
        dialogBox.GetComponent<Transform>().position = Vector2.right*10000;
        dialog.GetComponent<Dialog>().textComponent.text = "";
        player.GetComponent<PlayerMovement>().moveSpeed = 5f;
    }

    // 3- Substitute with selecting the corrrsponding Dialog Text Set
    //    Require object id and decision point id
    //    Hard Code Destinations
    /*
    public int getDialog(int id)
    {
        if (id == 0)
            return 0;
        if (id == 2)
            return 5;

        return dialog.GetComponent<Dialog>().dialogTextSetList.Length - 1;
    }
    */

    public int getDialog(int objId, int decPointId)
    {
        if (objId == 0)
            return 0;
        if (objId == 1)
        {
            if (decPointId == 0)
                return 0;
            if (decPointId == 2)
                return 5;
        }
            
        return dialog.GetComponent<Dialog>().dialogTextSetList.Length - 1;
    }
}
