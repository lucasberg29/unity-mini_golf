using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    [Header("Game Info")]
    [SerializeField]
    private bool _isPaused = false;

    [Header("Colour Palette")]
    public Color color1;
    public Color color2;
    public Color color3;
    public Color color4;
    public Color color5;

    [Header("Player Info")]
    [SerializeField]
    private int highestScore;
    [SerializeField]
    private int currentScore;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this);
        }
        else
        {
            _instance = this;
        }

        highestScore = PlayerPrefs.GetInt("HighestScore"); 
        //DontDestroyOnLoad(this);
    }

    //public static GameManager Instance
    //{
    //    get
    //    {
    //        if (_instance == null)
    //        {

    //            _instance = (GameManager)FindObjectOfType(typeof(GameManager));

    //            if (_instance == null)
    //            {
    //                GameObject go = new GameObject("_GameManager");
    //                go.AddComponent<GameManager>();
    //                _instance = go.GetComponent<GameManager>();
    //            }
    //        }

    //        return _instance;
    //    }
    //}

    public static GameManager Instance
    {
        get
        {
            if (!_instance)
            {
                var gameManagerPrefab = Resources.Load<GameObject>("Tools/_GameManager");
                var gameManagerObject = Instantiate<GameObject>(gameManagerPrefab);

                _instance = gameManagerObject.GetComponentInChildren<GameManager>();

                if (!_instance)
                {
                    _instance = gameManagerObject.AddComponent<GameManager>();
                }

                DontDestroyOnLoad(_instance.transform.root.gameObject);
            }
            return _instance;
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0.0f;
        _isPaused = true;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1.0f;
        _isPaused = false;
    }

    public bool GetIsPaused()
    {
        return _isPaused;
    }

    public int GetCurrentScore()
    {
        return currentScore;
    }

    public void SetCurrentScore( int score )
    {
        currentScore = score;   
    }

    public void AddOneToScore()
    {
        ++currentScore;
    }

    public int GetHighestScore()
    {
        return highestScore;
    }

    public void SetHighestScore( int score )
    {
        highestScore = score;
        PlayerPrefs.SetInt("HighestScore", highestScore);
    }

    public void DeleteScoreRecord()
    {
        PlayerPrefs.SetInt("HighestScore", 0);
        highestScore = 0;
    }

    public void PlayLevel( string scene )
    {
        SceneManager.LoadScene(scene);
    }
}
