using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    public MG_AnimationHandler animator;
    public MG_PlayerController playerController;
    public MG_UIManager uiManager;
    static GameManager gameManager;
    public GameObject playerObject;

    public static GameManager Instance
    {
        get { return gameManager; }
    }

    private void Awake()
    {
        gameManager = this;
    }
    void Start()
    {
        MGScoreManager.Instance.ResetScore();
    }

    public void GameOver()
    {
        uiManager.SetRestart();
        PlayerPrefs.SetInt("LastScore", MGScoreManager.Instance.currentScore);
        PlayerPrefs.Save();
        MGScoreManager.Instance.SaveHighScore();
        MGScoreManager.Instance.UpdateScore(MGScoreManager.Instance.currentScore);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    public void EndMiniGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
    }

    public void Damage()
    {
        if (playerController.PlayerHp == 3)
        {
            playerController.PlayerHp--;
            uiManager.Health1();
            animator.DamageOn();
        }
        else if (playerController.PlayerHp == 2)
        {
            playerController.PlayerHp--;
            uiManager.Health2();
            animator.DamageOn();
        }
        else if (playerController.PlayerHp == 1)
        {
            playerController.PlayerHp--;
            uiManager.Health3();
            animator.Die();
            playerController.PlayerSpeed = 0;

            StartCoroutine(GameOverDelay());
        }
    }

    private IEnumerator GameOverDelay()
    {
        yield return new WaitForSeconds(1.5f);
        GameOver();
    }

}