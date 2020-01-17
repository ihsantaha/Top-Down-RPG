using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        var obj = collision.gameObject.tag;

        if (obj == "Item")
            Destroy(collision.gameObject);
        if (obj == "BadObject")
            SceneManager.LoadSceneAsync(3);
    }
}
