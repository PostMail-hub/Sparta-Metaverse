using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    private int currentScore = 0;

    private void Awake()
    {
        gameManager = this;
    }

    public void GameOver()
    {
        Debug.Log("Game Over");
    }

    public void RestartGame()
    {
        Debug.Log("리스타트");
    }

    public void AddScore(int score)
    {
        Debug.Log("Score: " + currentScore);
        currentScore += score;
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
            Destroy(playerController, 1.5f);
        }
    }

}