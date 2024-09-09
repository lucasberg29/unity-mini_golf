using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MusicManager : MonoBehaviour
{
    public AudioSource menuMusic;
    public AudioSource level1;
    public AudioSource level2;
    public AudioSource level3;
    public AudioSource victory;

    public static MusicManager instance;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        menuMusic.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (instance == null)
        {
            instance = this;
        }

        Scene sceneManager = SceneManager.GetActiveScene();
        if (sceneManager.name != "Menu")
        {
            Cursor.visible = false;
        }
        else
        {
            Cursor.visible = true;
        }
    }

    public void PlayVictory()
    {
        victory.Play();
    }
}
