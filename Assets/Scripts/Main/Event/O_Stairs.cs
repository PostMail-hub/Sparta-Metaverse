using System.Collections;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.UI;

public class O_Stairs : MonoBehaviour
{
    public LoadScore loadScore;
    private bool IsTalk = false;
    private bool IsPlayerInRange = false;

    public GameObject KeyPanel; // 상호작용 하겠냐고 묻는 판넬
    public Text KeyText;

    public GameObject InteractionPanel; // 미니게임 진입 창이 뜨는 판넬

    void Update()
    {
        if (IsPlayerInRange && !IsTalk)
        {
            KeyPanel.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
            {
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
}