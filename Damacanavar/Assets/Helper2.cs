using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Helper2 : MonoBehaviour
{
    [SerializeField] private Text btnText;
    [SerializeField] private Text btnText2;

    public void GoMenu()
    {
        GameManager.Instance.LoadMenuScreen();
    }

    public void ToggleSound()
    {
        GameManager.Instance.isSoundOn = !GameManager.Instance.isSoundOn;
        btnText.text = (GameManager.Instance.isSoundOn) ? "ON" : "OFF";
        PlayerPrefs.SetInt("isSoundOn", GameManager.Instance.isSoundOn ? 1 : 0);
    }

    public void ToggleMusic()
    {
        GameManager.Instance.isMusicOn = !GameManager.Instance.isMusicOn;
        btnText2.text = (GameManager.Instance.isMusicOn) ? "ON" : "OFF";
        PlayerPrefs.SetInt("isMusicOn", GameManager.Instance.isMusicOn ? 1 : 0);
    }
}
