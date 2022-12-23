using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderMovement : MonoBehaviour
{
    //take a time variable 
    //lerp between two positions given
    [SerializeField] private float time;
    [SerializeField] private Transform firstPos;
    [SerializeField] private Transform lastPos;

    private bool onFirst;
    private bool onLast;
    private Vector3 dif;
    public Vector3 tempPos;

    private void Start()
    {
        transform.position = firstPos.position;
        dif = lastPos.position - firstPos.position;
        onFirst = true;
    }
    private void Update()
    {
        // MovePlatform();
        if (onFirst) transform.position += dif / (Time.deltaTime * time * 1000);
        if (onLast) transform.position -= dif / (Time.deltaTime * time * 1000);
        if (transform.position.x >= lastPos.position.x)
        {
            onFirst = false;
            onLast = true;
        }
        if (transform.position.x <= firstPos.position.x)
        {
            onFirst = true;
            onLast = false;
        }

    }

}