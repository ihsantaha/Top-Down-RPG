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
        decisionPointID = 0;
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

    public void OpenDialog(int objID, int decPointID)
    {
        var dialogTextSet = dialog.GetComponent<Dialog>().dialogTextSetList[getDialog(objID,decPointID)];

        if (IsOpenable() && !currentStateIsOpen && Input.GetButton("X Button"))
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
            if (dialogTextSetList[currentDialogTextIndex].isEndPoint && Input.GetButtonDown("A Button"))
            {
                CloseDialog();
            }
            else if (dialogTextSetList[currentDialogTextIndex].isDecisionPoint && Input.GetButtonDown("X Button"))
            {
                dialog.GetComponent<Dialog>().textComponent.text = dialogTextSetList[getDialog(objectID, currentDialogTextIndex)].dialogText;
                currentDialogTextIndex = getDialog(objectID, currentDialogTextIndex);
            }
            else if (Input.GetButtonDown("A Button"))
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
