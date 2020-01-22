using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogLoader : MonoBehaviour
{
    public GameObject dialogBox;
    public GameObject dialog;
    public GameObject player;
    public bool activate;
    public bool currentStateIsOpen;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        CheckActivation();
        CheckDeactivation();
    }

    public void CheckActivation()
    {

        if (player.GetComponent<PlayerCollision>().attemptToSleep)
        {
            OpenDialog();
            player.GetComponent<PlayerCollision>().attemptToSleep = false;
        }
    }

    public void OpenDialog()
    {
        if (!currentStateIsOpen)
        {
            Instantiate(dialogBox, Vector3.zero, transform.rotation);
            Instantiate(dialog, Vector3.zero, transform.rotation);
            currentStateIsOpen = true;
        }
    }

    public void CheckDeactivation()
    {
        if (currentStateIsOpen) {
            player.GetComponent<PlayerMovement>().moveSpeed = 0;
            if (Input.GetKeyDown(KeyCode.N))
            {
                CloseDialog();
                currentStateIsOpen = false;
                player.GetComponent<PlayerMovement>().moveSpeed = 5f;
            }
        }
    }

    public void CloseDialog()
    {
        Destroy(GameObject.FindGameObjectWithTag("DialogBox"));
    }

    public void Accept()
    {
        Debug.Log("Next Action (Go to next set of text or got to sleep)");
    }
}
