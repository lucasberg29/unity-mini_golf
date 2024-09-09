using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallForce : MonoBehaviour
{
    private int stroke;
    private int score = 0;
    
    private float forceAcumulated;

    public Text forceText;
    public Text strokeText;
    
    public void IncreaseScore()
    {
        score = score + 1;
        forceText.text = "FORCE: " + score;
    }

    public void SetForce(int score)
    {
        this.score = score;
        forceText.text = "FORCE: " + score;
    }

    public void AddStroke()
    {
        stroke += 1;
        strokeText.text = "STROKE: " + stroke;
    }

    public void ResetScore()
    {
        score = 0;
        forceText.text = "SCORE: " + score;
    }
}
