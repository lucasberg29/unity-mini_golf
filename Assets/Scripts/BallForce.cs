using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BallForce : MonoBehaviour
{
    private int strike;
    private int score = 0;
    
    private float forceAccumulated;

    public TextMeshProUGUI forceText;
    public TextMeshProUGUI strikeText;

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
        strike += 1;
        strikeText.text = "Strikes: " + strike;
    }

    public void ResetScore()
    {
        score = 0;
        forceText.text = "SCORE: " + score;
    }
}
