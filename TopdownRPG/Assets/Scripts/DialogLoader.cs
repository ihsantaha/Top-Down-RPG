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
    public int currentDialogTextIndex;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        dialogBox = GameObject.FindGameObjectWithTag("DialogBox");
        dialogBox.GetComponent<Transform>().position = Vector2.right * 1000;
    }

    void Update()
    {
        IsOpenable();
        OpenDialog();
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

    public void OpenDialog()
    {
        if (IsOpenable() && !currentStateIsOpen && Input.GetKeyDown(KeyCode.X))
        {
            currentStateIsOpen = true;
            currentDialogTextIndex = 1;
            dialogBox.GetComponent<Transform>().position = Vector2.zero;
            Instantiate(dialog, Vector3.zero, transform.rotation);
            dialog.GetComponent<Dialog>().textComponent.text = dialog.GetComponent<Dialog>().dialogTextSet[0];
            player.GetComponent<PlayerMovement>().moveSpeed = 0;
        }
    }

    public void ManageDialog()
    {
        if (currentStateIsOpen && currentDialogTextIndex < dialog.GetComponent<Dialog>().dialogTextSet.Length && Input.GetKeyDown(KeyCode.N))
        {
            dialog.GetComponent<Dialog>().textComponent.text = dialog.GetComponent<Dialog>().dialogTextSet[currentDialogTextIndex];
            currentDialogTextIndex++;
        }
        else if (currentStateIsOpen && currentDialogTextIndex >= dialog.GetComponent<Dialog>().dialogTextSet.Length && Input.GetKeyDown(KeyCode.N))
        {
            currentDialogTextIndex = 1;
            CloseDialog();
        }
    }

    public void CloseDialog()
    {
        currentStateIsOpen = false;
        dialogBox.GetComponent<Transform>().position = Vector2.right*10000;
        dialog.GetComponent<Dialog>().textComponent.text = "";
        player.GetComponent<PlayerMovement>().moveSpeed = 5f;
        currentDialogTextIndex = 1;

    }
}
