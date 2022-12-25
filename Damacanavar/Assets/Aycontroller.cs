using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aycontroller : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    public float screenWidth;
    private Vector2 size;
    private void Start()
    {
        screenWidth = Camera.main.orthographicSize * Camera.main.aspect;

        size = GetComponent<SpriteRenderer>().bounds.size;
    }
    private void FixedUpdate()
    {
        transform.Translate(new Vector3(-1, 0, 0) * Time.fixedDeltaTime * speed);

        if (transform.position.x <= -screenWidth - size.x / 2 - 0.3f)
        {
            transform.position = new Vector3(screenWidth + size.x / 2 + 0.3f, transform.position.y);
        }

    }
}
