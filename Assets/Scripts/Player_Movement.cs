using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Tilemaps;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public float moveSpeed = 1f; // Movement speed of the tank
    public float jumpForce = 10f; // Jumping force of the tank
    private Rigidbody2D rb;
    private bool isGrounded = false; // Checking if the tank is on the ground
    public bool facingRight = true; // Checking if the tank is facing right
    private Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveInput = 0; // Initial horizontal movement, no movement yet

        if (Input.GetKey(KeyCode.D)) // If the D key is pressed, being moving right
        {
            moveInput = 1;
        }

        else if (Input.GetKey(KeyCode.A)) // If the A key is pressed, begin moving left
        {
            moveInput = -1;
        }

        movement = new Vector2(moveInput * moveSpeed, rb.velocity.y); // Setting the movement velocity

        if (moveInput > 0 && !facingRight) // Flipping the tank's sprite
        {
            Flip();
        }

        else if (moveInput < 0 && facingRight)
        {
            Flip();
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) // Checking to see if the user is grounded when the jump key is pressed, if so then the jump force is applied
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce); // Setting the jump velocity
        }
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(movement.x, rb.velocity.y); // Applying the horizontal movement
    }

    void Flip () // Flipping the tank's sprite and it's firepoint
    {
        facingRight = !facingRight;

        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;

    }

    private void OnCollisionEnter2D(Collision2D collision) // Detecting whether the player is touching the ground or not for
    {
        if (collision.gameObject.CompareTag("Ground")) 
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
