using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timerscript : MonoBehaviour
{
    public Text timeText;
    private int current = 86280;
    private void Start()
    {
        StartCoroutine(InceaseTime());
    }

    void Update()
    {
        // // Calculate the time remaining until 00:00:00
        // System.TimeSpan timeHedef = new System.TimeSpan(23, 59, 59);
        // System.TimeSpan timeRemaining = timeHedef - currentTime;
        // currentTime.Add(new System.TimeSpan(0, 0, 1));
        // // Update the text of the UI element
        // timeText.text = string.Format("{0:00}:{1:00}:{2:00}", timeRemaining.Hours, timeRemaining.Minutes, timeRemaining.Seconds);
    }

    IEnumerator InceaseTime()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(1);
            Debug.Log("adasd");
            current++;
            asdd();
        }

    }

    public void asdd()
    {
        var hours = current / 60 / 60;
        var x = current - (hours * 60);

        var min = x / 60 / 60;

        x = x - (min * 60);

        var sec = x;


        timeText.text = string.Format("{0:00}:{1:00}:{2:00}", hours, min, sec);
        Debug.Log(timeText.text);





    }
}
