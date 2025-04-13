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

        GameObject fontManager = GameObject.FindGameObjectWithTag("FontManager");

        if (fontManager == null)
        {
            Instantiate(fontManager);
        }
        else
        {
            fontManager.GetComponent<FontManager>().GetTextsFromScene();
        }

        UpdateCursor();
    }

    private void UpdateCursor()
    {
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
