using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timerscript : MonoBehaviour
{
    public Text timeText;
    System.TimeSpan currentTime;
    private void Start()
    {
        currentTime = new System.TimeSpan(23, 58, 00);
    }

    void Update()
    {
        // Calculate the time remaining until 00:00:00
        System.TimeSpan timeHedef = new System.TimeSpan(23, 59, 59);
        System.TimeSpan timeRemaining = timeHedef - currentTime;
        currentTime.Add(new System.TimeSpan(0, 0, 1));
        // Update the text of the UI element
        timeText.text = string.Format("{0:00}:{1:00}:{2:00}", timeRemaining.Hours, timeRemaining.Minutes, timeRemaining.Seconds);
    }

}
