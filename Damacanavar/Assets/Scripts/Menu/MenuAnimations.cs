using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAnimations : MonoBehaviour
{
    private bool isWhite = false;
    float waitFor = 001f;
    float lastChecked;
    [SerializeField] private GameObject whiteLettersBg;

    private void Start() {
        lastChecked = Time.time;
    }

    private void Update() {
        // Debug.Log((lastChecked+waitFor) + " -- " + Time.time + " -- " + lastChecked);
        if(lastChecked + waitFor <= Time.time)
        {
            waitFor = Random.Range(0.1f, 0.01f);
            if(Random.Range(1, 100) <= 20) waitFor = 1f;
            lastChecked = Time.time;
            ToggleWhiteLetters();
        }
    }
    private void ToggleWhiteLetters()
    {
        isWhite = !isWhite;
        whiteLettersBg.SetActive(isWhite);
    }
}
