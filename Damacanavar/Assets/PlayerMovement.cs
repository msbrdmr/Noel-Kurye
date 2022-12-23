using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;

    public int jumpsAmount;
    int jumpsLeft;
    public Transform GroundCheck;
    public LayerMask GroundLayer;

    bool isGrounded;

    float moveInput;
    Rigidbody2D rb2d;
    float scaleX;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        scaleX = transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        Jump();

    }

    private void FixedUpdate()
    {
        Move();
    }

    public void Move()
    {
        Flip();
        rb2d.velocity = new Vector2(moveInput * moveSpeed * Time.fixedDeltaTime, rb2d.velocity.y);
    }

    public void Flip()
    {
        if (moveInput > 0)
        {
            transform.localScale = new Vector3(scaleX, transform.localScale.y, transform.localScale.z);
        }
        if (moveInput < 0)
        {
            transform.localScale = new Vector3((-1) * scaleX, transform.localScale.y, transform.localScale.z);
        }
    }

    public void Jump()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            CheckIfGrounded();
            if (jumpsLeft > 0)
            {
                rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce * Time.deltaTime);
                jumpsLeft--;
            }

        }

    }

    public void CheckIfGrounded()
    {
        isGrounded = Physics2D.OverlapCircle(GroundCheck.position, GroundCheck.GetComponent<CircleCollider2D>().radius, GroundLayer);
        ResetJumps();
    }

    public void ResetJumps()
    {
        if (isGrounded)
        {
            jumpsLeft = jumpsAmount;// jumpsAmount =2;
        }
    }


}
