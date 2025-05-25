using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject musicManager;
    public GameObject fontManager;

    void Start()
    {
        if (GameObject.FindGameObjectWithTag("MusicManager") == null)
        {
            Instantiate(musicManager);
        }

        GameObject currentFontManager = GameObject.FindGameObjectWithTag("FontManager");
        if (currentFontManager == null)
        {
            Instantiate(fontManager);
            DontDestroyOnLoad(fontManager);
        }
        else
        {
            currentFontManager.GetComponent<FontManager>().GetTextsFromScene();
        }

        UpdateCursor();
    }

    private void UpdateCursor()
    {
        Scene sceneManager = SceneManager.GetActiveScene();
        if (sceneManager.name != "Menu")
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.visible = true;
        }
    }

    void Update()
    {
        
    }
}
