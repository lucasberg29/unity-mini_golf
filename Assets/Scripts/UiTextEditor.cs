using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class UiTextEditor : MonoBehaviour
{
    private int currentWidth;

    List<TextMeshProUGUI> textMeshPro;

    public float webGlFontSize;
    public float hdFontSize;
    public float fullHdFontSize;

    // Start is called before the first frame update
    void Start()
    {
        textMeshPro = GameObject.FindObjectsOfType<TextMeshProUGUI>().ToList(); 

        if (textMeshPro.First().fontSize != fullHdFontSize || Screen.width != 1920)
        {
            AdjustFontSize();
        }
        else
        {
            currentWidth = Screen.width;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (currentWidth != Screen.width)
        {
            AdjustFontSize();
            currentWidth = Screen.width;
        }
    }

    private void AdjustFontSize()
    {
        int width = Screen.width;
        float fontSize = textMeshPro.First().fontSize;    

        if (width >= 1920)
        {
            fontSize = fullHdFontSize;
        }
        else if (width >= 1280)
        {
            fontSize = hdFontSize;
        }
        else if (width >= 960)
        {
            fontSize = webGlFontSize;
        }

        for (int i = 0; i < textMeshPro.Count(); i++)
        {
            textMeshPro[i].fontSize = fontSize;
        }
    }
}
