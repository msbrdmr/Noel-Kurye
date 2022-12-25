using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class finishCheck : MonoBehaviour
{

    public GameObject finishButton;
    public int currentpresents;
    public Text PresentCountText;

    public int finishPresentCount = 30;
    private void Start()
    {
        // PresentCountText.text = finishPresentCount.ToString();
    }
    private void Update()
    {
        currentpresents = int.Parse(PresentCountText.text);
        Debug.Log(currentpresents);
        if (currentpresents >= finishPresentCount)
        {
            finishButton.SetActive(true);
        }
    }
}
