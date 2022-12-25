using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region Singleton
    private static GameManager instance = null;
    public static GameManager Instance
    {
        get
        {
            // if (instance == null)
            // {
            //     instance = new GameObject("GameManager").AddComponent<GameManager>();
            // }
            return instance;
        }
    }

    private void OnEnable()
    {

    }

    #endregion

    [SerializeField] private Text btnText;
    public bool isSoundOn = true;
    public bool isMusicOn = true;
    public int goldAmount = 0;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
    private void Start()
    {
        int isSoundOnInt = PlayerPrefs.GetInt("isSoundOn", 1);
        int isMusicOnInt = PlayerPrefs.GetInt("isMusicOn", 1);
        isSoundOn = isSoundOnInt == 0 ? false : true;
        isMusicOn = isMusicOnInt == 0 ? false : true;
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



    public void LoadSettingsScene()
    {
        SceneManager.LoadScene("Settings");
    }

    public void LoadMenuScreen()
    {
        SceneManager.LoadScene("Menu");
    }
}
