using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] public float moveForce = 5f;
    [SerializeField] public float maxSpeed = 5f;
    [SerializeField] public float jumpForce = 5f;

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

        if (Input.GetKey(KeyCode.Space))
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

    private void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
}
