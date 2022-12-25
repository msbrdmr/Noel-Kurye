using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxPush2 : MonoBehaviour
{
    private float pushValue = 1f;
    private bool isGoingUp;
    [SerializeField] private GameObject player;

    private float decrement = 1.6f;


    private float minY, maxY;
    [SerializeField] private GameObject playBox, settingsBox, quitBox;
    [SerializeField]
    private Sprite playWhite, playBlack,
                                    settingsWhite, settingsBlack,
                                    quitWhite, quitblack;

    private SpriteRenderer sr;

    private void Start()
    {
        maxY = transform.position.y;
        minY = maxY - decrement;
        sr = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Collision Enter");
            switch (this.gameObject.tag)
            {
                case "PLAY":
                    Debug.Log("Make Play Black");
                    sr.sprite = playBlack;
                    break;
                case "SETTINGS":
                    sr.sprite = settingsBlack;
                    break;
                case "QUIT":
                    sr.sprite = quitblack;
                    break;
                default:
                    break;
            }
        }
    }


    private void OnCollisionStay2D(Collision2D other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            player.transform.position -= new Vector3(0, pushValue, 0) * Time.deltaTime;
            transform.position -= new Vector3(0, pushValue, 0) * Time.deltaTime;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (transform.position.y <= maxY)
            {
                isGoingUp = true;
            }
            Debug.Log("Collision Exit");
            switch (this.gameObject.tag)
            {
                case "PLAY":
                    sr.sprite = playWhite;
                    break;
                case "SETTINGS":
                    sr.sprite = settingsWhite;
                    break;
                case "QUIT":
                    sr.sprite = quitWhite;
                    break;
                default:
                    break;
            }
        }
    }

    private void Update()
    {
        if (isGoingUp)
        {
            transform.position += new Vector3(0, pushValue, 0) * Time.deltaTime;
            if (transform.position.y >= maxY) isGoingUp = false;
        }

        if (transform.position.y <= minY)
        {
            Debug.Log(this.gameObject.tag);
            pushValue = 0;
            switch (this.gameObject.tag)
            {
                case "PLAY":
                    GameManager.Instance.LoadGameScene();
                    break;
                case "SETTINGS":
                    break;
                case "QUIT":
                    break;
                default:
                    break;
            }
        }
    }
}
