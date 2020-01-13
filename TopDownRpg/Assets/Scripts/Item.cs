using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public GameObject item;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerMovement player = collision.GetComponent<PlayerMovement>(); 

        if(player != null)
        {
            item = GameObject.Find("Potion");
            Debug.Log("we have touched a character");
            Destroy(item);
        }
    }
}
