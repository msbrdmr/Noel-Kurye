using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementMenu : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float playerSpeed = 5f;
    [SerializeField] private float jumpForce = 5f;
    void Start()
    {
        // rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.D))             // (x, y) -- (1, 0)
        {
            rb.velocity += Vector2.right * Time.deltaTime * playerSpeed;
        }
        if(Input.GetKey(KeyCode.A))
        {
            rb.velocity += Vector2.left * Time.deltaTime * playerSpeed;
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * Time.deltaTime * jumpForce);  // (0, 1)
        }

        Debug.Log(Time.deltaTime);
    }
}
