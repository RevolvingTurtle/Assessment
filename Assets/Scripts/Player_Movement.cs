using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Tilemaps;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float jumpForce = 10f;
    private Rigidbody2D rb;
    private bool isGrounded = false;
    public bool facingRight = true;
    private Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveInput = 0; // Movement: Gets the player's movement depending on which key is pressed A/D or Left/Right arrow keys by default, then moves left or right accordingly

        if (Input.GetKey(KeyCode.D))
        {
            moveInput = 1;
        }

        else if (Input.GetKey(KeyCode.A))
        {
            moveInput = -1;
        }

        Debug.Log("Move input: " + moveInput);

        movement = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        if (moveInput > 0 && !facingRight)
        {
            Flip();
        }

        else if (moveInput < 0 && facingRight)
        {
            Flip();
        }

        // Jumping
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) // Checking to see if the user is grounded when the jump key is pressed, if so then the jump force is applied
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(movement.x, rb.velocity.y);
    }

    void Flip ()
    {
        facingRight = !facingRight;

        Debug.Log("now facing rightL " + facingRight);

        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;

    }

    // Detecting whether the player is touching the ground or not
    private void OnCollisionEnter2D(Collision2D collision)
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
