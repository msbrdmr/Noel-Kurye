using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Starscontroller : MonoBehaviour
{
    public List<GameObject> stars;
    public float screenWidth;
    [SerializeField] private float speed = 10f;

    private Vector2 size;

    private void Start()
    {
        screenWidth = Camera.main.orthographicSize * Camera.main.aspect;
        size = stars[0].GetComponent<SpriteRenderer>().bounds.size;
    }
    private void FixedUpdate()
    {
        foreach (var item in stars)
        {
            item.transform.Translate(new Vector3(-1, 0, 0) * Time.fixedDeltaTime * speed);
            if (item.transform.position.x <= -screenWidth - size.x / 2)
            {
                item.transform.position = new Vector3(screenWidth + size.x / 2, item.transform.position.y);
            }
        }

    }
}
