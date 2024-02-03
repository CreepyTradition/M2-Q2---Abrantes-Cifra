using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveForce = 4f;
    public float maxSpeed = 3f;
    public float jumpForce = 10f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Setting Left & Right Inputs
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(horizontalInput,0f).normalized;

        MovePlayer(movement);

        // Setting Jump Input

        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
    }

    void MovePlayer(Vector3 movement) 
    {
        // Moving the player
        rb.AddForce(movement * moveForce);

        // Limit the player's speed
        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }
    }

    void Jump()
    {
        // Apply upward force for the jump
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
}
