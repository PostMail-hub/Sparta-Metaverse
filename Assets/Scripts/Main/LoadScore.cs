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
        ScoreRenewal();
    }

    public void ScoreRenewal()
    {
        int lastScore = PlayerPrefs.GetInt("LastScore", 0);
        int bestScore = PlayerPrefs.GetInt("HighScore", 0);

        lastScoreText.text = lastScore.ToString();
        bestscoreText.text = bestScore.ToString();
    }
}

