using System.Collections;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.UI;

public class O_Stairs : MonoBehaviour
{
    public AudioClip StairsSoundClip;

    public LoadScore loadScore;
    private bool IsTalk = false;
    private bool IsPlayerInRange = false;

    public GameObject KeyPanel; // ��ȣ�ۿ� �ϰڳİ� ���� �ǳ�
    public Text KeyText;

    public GameObject InteractionPanel; // �̴ϰ��� ���� â�� �ߴ� �ǳ�

    void Update()
    {
        if (IsPlayerInRange && !IsTalk)
        {
            KeyPanel.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
            {
                if (StairsSoundClip != null)
                    StartCoroutine(PlayAudioRepeatedly());

                KeyPanel.SetActive(false);
                IsTalk = true;
                InteractionPanel.SetActive(true);
                loadScore.ScoreRenewal();
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            IsTalk = false;
            InteractionPanel.SetActive(false);
        }
        if (!IsPlayerInRange)
        {
            IsTalk = false;
            InteractionPanel.SetActive(false);
        }
    }



    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            IsPlayerInRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            KeyPanel.SetActive(false);
            IsPlayerInRange = false;
        }
    }

    private IEnumerator PlayAudioRepeatedly()
    {
        for (int i = 0; i < 4; i++)
        {
            SoundManager.PlayClip(StairsSoundClip);
            yield return new WaitForSeconds(0.18f);
        }
    }

}