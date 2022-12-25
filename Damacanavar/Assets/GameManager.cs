using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region Singleton
    private static GameManager instance = null;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameObject("GameManager").AddComponent<GameManager>();
            }
            return instance;
        }
    }

    private void OnEnable()
    {
        instance = this;
    }

    #endregion

    public bool isSoundOn = true;
    public int goldAmount = 0;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

        int isSoundOnInt = PlayerPrefs.GetInt("isSoundOn", 1);
        isSoundOn = isSoundOnInt == 0 ? false : true;
    }

    public void LoadGameScene()
    {
        SceneManager.LoadScene("Level 2");
    }

    public void LoadIntroScene()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void IncreaseGold()
    {
        goldAmount += 1;
    }

    public void setAudioVolume(float volume)
    {
        PlayerPrefs.SetFloat("audioVolume", volume);
    }
    public void setMusicVolume(float volume)
    {
        PlayerPrefs.SetFloat("musicVolume", volume);
    }
}
