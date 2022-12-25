using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skipController : MonoBehaviour
{
    private int counter = 0;
    public List<Sprite> textspriteList;
    private SpriteRenderer sr;
    public GameObject dialogue;
    public GameObject canvas;
    private void Start() {
        sr = dialogue.GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            counter += 1;
            changeText();
        }
    }
    public void changeText()
    {
        try{
            sr.sprite = textspriteList[counter];
        }
        catch
        {
            canvas.SetActive(true);
        }
    }

    public void LoadGame()
    {
        GameManager.Instance.LoadGameScene();
    }
}
