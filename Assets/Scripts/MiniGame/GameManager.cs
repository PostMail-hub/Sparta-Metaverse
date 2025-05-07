using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    public AudioClip ButtonSoundClip;
    public AudioClip PlayerDamageClip;
    public AudioClip PlayerDieClip;

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

    public void GameOver()
    {
        MGScoreManager.Instance.SaveAllScores();
        uiManager.SetRestart();
    }

    public void StartGame()
    {
        if (ButtonSoundClip != null)
            SoundManager.PlayClip(ButtonSoundClip);
        UnityEngine.SceneManagement.SceneManager.LoadScene("MiniGameScene");
    }

    public void RestartGame()
    {
        if (ButtonSoundClip != null)
            SoundManager.PlayClip(ButtonSoundClip);
        MGScoreManager.Instance.ResetScore();
        UnityEngine.SceneManagement.SceneManager.LoadScene("MiniGameScene");

    }

    public void EndMiniGame()
    {
        if (ButtonSoundClip != null)
            SoundManager.PlayClip(ButtonSoundClip);
        UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
    }

    public void Damage()
    {
        if (playerController.PlayerHp == 3)
        {
            playerController.PlayerHp--;
            uiManager.Health1();
            animator.DamageOn();
            if (PlayerDamageClip != null)
                SoundManager.PlayClip(PlayerDamageClip);

        }
        else if (playerController.PlayerHp == 2)
        {
            playerController.PlayerHp--;
            uiManager.Health2();
            animator.DamageOn();
            if (PlayerDamageClip != null)
                SoundManager.PlayClip(PlayerDamageClip);
        }
        else if (playerController.PlayerHp == 1)
        {
            playerController.PlayerHp--;
            uiManager.Health3();
            animator.Die();
            playerController.PlayerSpeed = 0;
            if (PlayerDieClip != null)
                SoundManager.PlayClip(PlayerDieClip);

            StartCoroutine(GameOverDelay());
        }
    }

    private IEnumerator GameOverDelay()
    {
        int finalScore = MGScoreManager.Instance.currentScore;

        yield return new WaitForSeconds(1.5f);
        GameOver();
    }

}