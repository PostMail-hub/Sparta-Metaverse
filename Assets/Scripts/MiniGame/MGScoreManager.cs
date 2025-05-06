using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class MGScoreManager : MonoBehaviour
{

    public static MGScoreManager Instance { get; private set; }

    public MG_UIManager uiManager;
    public GameManager gameManager;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI bestscoreText;

    public int currentScore = 0;
    public int bestScore = 0;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            bestScore = PlayerPrefs.GetInt("HighScore", 0);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddScore(int score)
    {
        currentScore += score;
        if (currentScore > bestScore)
        {
            bestScore = currentScore;
            PlayerPrefs.SetInt("HighScore", bestScore);
            PlayerPrefs.Save();
        }
        UpdateScore(currentScore);
    }

    public void UpdateScore(int score)
    {
        if (scoreText != null)
            scoreText.text = score.ToString();

        bestScore = PlayerPrefs.GetInt("HighScore", 0);

        if (bestscoreText != null)
            bestscoreText.text = bestScore.ToString();
    }

    public void ResetScore()
    {
        currentScore = 0;
        UpdateScore(0);
    }

    public void SaveHighScore()
    {
        if (currentScore > bestScore)
        {
            bestScore = currentScore;
            PlayerPrefs.SetInt("HighScore", bestScore);
            PlayerPrefs.Save();
        }
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scoreText == null)
            scoreText = GameObject.Find("ScoreNum")?.GetComponent<TextMeshProUGUI>();

        if (bestscoreText == null)
            bestscoreText = GameObject.Find("BestScoreNum")?.GetComponent<TextMeshProUGUI>();

        if (uiManager == null)
            uiManager = GameObject.Find("UIManager")?.GetComponent<MG_UIManager>();

        if (gameManager == null)
            gameManager = GameObject.Find("MiniGameManager")?.GetComponent<GameManager>();

        bestScore = PlayerPrefs.GetInt("HighScore", 0);

        UpdateScore(currentScore);
    }
}
