using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LoadScore : MonoBehaviour
{
    public TextMeshProUGUI lastScoreText;
    public TextMeshProUGUI bestscoreText;

    void Start()
    { 
    }

    public void ScoreRenewal()
    {
        int lastScore = PlayerPrefs.GetInt("LastScore", 0);
        int bestScore = PlayerPrefs.GetInt("HighScore", 0);

        if (lastScore != null)
            lastScoreText.text = lastScore.ToString();

        if (bestScore != null)
            bestscoreText.text = bestScore.ToString();
    }
}
