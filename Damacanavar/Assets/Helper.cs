using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helper : MonoBehaviour
{
    public void LoadGameScene()
    {
        Debug.Log("Annen");
        GameManager.Instance.LoadGameScene();
    }
}
