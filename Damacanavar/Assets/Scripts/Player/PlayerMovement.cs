using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 3f;
    public float wallSlideSpeed = 3f;

    public Transform groundCheck;
    public LayerMask groundLayer;
    public LayerMask sliderLayer;

    public bool isGrounded;
    public Collider2D isOnSlider;
    public bool isTouchingWall;
    public bool isWallSliding;

    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private bool isFacingRight = true;
    private CircleCollider2D groundCollider;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        groundCollider = groundCheck.GetComponent<CircleCollider2D>();
    }

    private void Update()
    {
        // Check if the player is touching the ground
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCollider.radius, groundLayer);
        isOnSlider = Physics2D.OverlapCircle(groundCheck.position, groundCollider.radius, sliderLayer);
        // Check if the player is touching a wall
        isTouchingWall = Physics2D.OverlapCircle(groundCheck.position, groundCollider.radius, LayerMask.GetMask("Wall"));

        // Update the animator with the current speed
        // animator.SetFloat("Speed", Mathf.Abs(rb.velocity.x));

        // Update the animator with the current jump state
        // animator.SetBool("IsJumping", !isGrounded);

        // Check if the player should start wall sliding
        if (isTouchingWall && !isGrounded && rb.velocity.y < 0)
        {
            isWallSliding = true;
        }
        else
        {
            isWallSliding = false;
        }

        // Update the animator with the current wall slide state
        // animator.SetBool("IsWallSliding", isWallSliding);
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }

        if (isOnSlider)
        {
            Debug.Log("here");
            transform.SetParent(isOnSlider.gameObject.transform);
        }
        else
        {
            transform.SetParent(null);
        }
    }

    private void FixedUpdate()
    {
        // Get the horizontal input
        float horizontalInput = Input.GetAxisRaw("Horizontal");

        // Calculate the movement
        Vector2 movement = new Vector2(horizontalInput * moveSpeed * Time.fixedDeltaTime, rb.velocity.y);

        // Check if the player should start wall sliding
        if (isTouchingWall && !isGrounded && rb.velocity.y < 0)
        {
            movement.x = 0f;
            movement.y = -wallSlideSpeed * Time.fixedDeltaTime;
        }

        // Apply the movement to the rigidbody
        rb.velocity = movement;

        // Flip the sprite if the player is moving horizontally
        if (horizontalInput > 0 && !isFacingRight)
        {
            FlipSprite();
        }
        else if (horizontalInput < 0 && isFacingRight)
        {
            FlipSprite();
        }
    }

    private void FlipSprite()
    {
        isFacingRight = !isFacingRight;
        spriteRenderer.flipX = !spriteRenderer.flipX;
    }

    public void Jump()
    {
        // Check if the player is able to jump
        if (isGrounded || isWallSliding)
        {
            // Add a force to the player's rigidbody to make them jump
            rb.AddForce(new Vector2(0f, jumpForce * Time.deltaTime), ForceMode2D.Impulse);
        }
    }
}