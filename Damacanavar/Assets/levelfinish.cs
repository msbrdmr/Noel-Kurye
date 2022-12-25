using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelfinish : MonoBehaviour
{

    public void finishGame()
    {
        SceneManager.LoadScene("Finish");
    }
}
