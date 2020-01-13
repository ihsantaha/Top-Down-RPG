using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D body;

    Vector2 movement;

    void Update()
    { 
        getInput();
    }

    private void FixedUpdate()
    {
        Move();
    }

    void getInput()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    void Move()
    {
        body.MovePosition(body.position + movement * moveSpeed * Time.fixedDeltaTime);
    }



}
