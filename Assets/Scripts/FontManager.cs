using NUnit.Framework;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class FontManager : MonoBehaviour
{
    public List<TextMeshProUGUI> textsInScene;

    private int currentWidth = 0;

    void Start()
    {
        textsInScene = new List<TextMeshProUGUI>(GameObject.FindObjectsByType<TextMeshProUGUI>(FindObjectsSortMode.None));
        //DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        currentWidth = Screen.width;

        foreach (var text in textsInScene)
        {
            if (currentWidth >= 1900)
            {
                if (text.gameObject.name == "GameTitle")
                {
                    text.fontSize = 140;
                }

                if (text.gameObject.name == "StartButtonText")
                {
                    text.fontSize = 60;
                }

                if (text.gameObject.name == "QuitButtonText")
                {
                    text.fontSize = 60;
                }

                if (text.gameObject.name == "GamePausedTitleText")
                {
                    text.fontSize = 50;
                }

                if (text.gameObject.name == "ResumeButtonText")
                {
                    text.fontSize = 40;
                }

                if (text.gameObject.name == "ResumeButtonText")
                {
                    text.fontSize = 30;
                }
            }

            if (currentWidth < 1900 && currentWidth >= 1600)
            {
                if (text.gameObject.name == "GameTitle")
                {
                    text.fontSize = 100;
                }

                if (text.gameObject.name == "StartButtonText")
                {
                    text.fontSize = 45;
                }

                if (text.gameObject.name == "QuitButtonText")
                {
                    text.fontSize = 45;
                }

                if (text.gameObject.name == "GamePausedTitleText")
                {
                    text.fontSize = 50;
                }

                if (text.gameObject.name == "ResumeButtonText")
                {
                    text.fontSize = 30;
                }
            }

            if (currentWidth < 1600 && currentWidth >= 1280)
            {
                if (text.gameObject.name == "GameTitle")
                {
                    text.fontSize = 80;
                }

                if (text.gameObject.name == "StartButtonText")
                {
                    text.fontSize = 30;
                }

                if (text.gameObject.name == "QuitButtonText")
                {
                    text.fontSize = 30;
                }

                if (text.gameObject.name == "GamePausedTitleText")
                {
                    text.fontSize = 30;
                }

                if (text.gameObject.name == "ResumeButtonText")
                {
                    text.fontSize = 20;
                }
            }


            if (currentWidth < 1200 && currentWidth >= 900)
            {
                if (text.gameObject.name == "GameTitle")
                {
                    text.fontSize = 80;
                }

                if (text.gameObject.name == "StartButtonText")
                {
                    text.fontSize = 30;
                }

                if (text.gameObject.name == "QuitButtonText")
                {
                    text.fontSize = 30;
                }

                if (text.gameObject.name == "GamePausedTitleText")
                {
                    text.fontSize = 30;
                }

                if (text.gameObject.name == "ResumeButtonText")
                {
                    text.fontSize = 20;
                }
            }
        }
    }

    public void GetTextsFromScene()
    {
        textsInScene = new List<TextMeshProUGUI>(GameObject.FindObjectsByType<TextMeshProUGUI>(FindObjectsSortMode.None));
    }
}
