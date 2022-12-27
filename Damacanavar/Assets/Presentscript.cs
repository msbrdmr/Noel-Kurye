using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Presentscript : MonoBehaviour
{
    public int presentPrice = 10;
    private int presentCount = 0;
    public Text presentText;

    void Update()
    {

    }

    public void buyPresent()
    {
        if (GameManager.Instance.goldAmount >= presentPrice)
        {
            GameManager.Instance.goldAmount -= presentPrice;
            FindObjectOfType<GoldUpdater>().UpdateGoldTextt();

            presentCount++;
            presentText.text = presentCount.ToString();
        }

    }
}
