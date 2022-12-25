using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementMenu : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float playerSpeed = 5f;
    [SerializeField] private float jumpForce = 5f;
    private Animator animator;
    private SpriteRenderer sr;
    private Vector3 startingPos;

    private float threshold = .1f;
    void Start()
    {
        startingPos = transform.position;
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))             // (x, y) -- (1, 0)
        {
            rb.velocity += Vector2.right * Time.deltaTime * playerSpeed;
            sr.flipX = false;
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity += Vector2.left * Time.deltaTime * playerSpeed;
            sr.flipX = true;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * Time.deltaTime * jumpForce);  // (0, 1)
        }

        // Debug.Log(Time.deltaTime);
    }


    private void FixedUpdate()
    {
        animator.SetBool("isWalking", Mathf.Abs(rb.velocity.x) >= threshold);
        if(transform.position.y <= -3f)
        {
            transform.position = startingPos + Vector3.up;
        }
    }
}
