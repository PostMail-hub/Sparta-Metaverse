using System.Collections;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.UI;

public class N_ElfEvent : MonoBehaviour
{

    private bool isTalk = false;
    private bool isPlayerInRange = false;

    public GameObject KeyPanel; // 상호작용 하겠냐고 묻는 판넬
    public Text KeyText;

    public GameObject InteractionPanel; //NPC의 대사가 출력되는 판넬
    public Text InteractionText;

    void Update()
    {
        if (isPlayerInRange && !isTalk)
        {
            KeyPanel.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
            {
                KeyPanel.SetActive(false);
                isTalk = true;
                StartCoroutine(ShowTalkMessage());
                StartCoroutine(ResetTalkOpenState());
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            KeyPanel.SetActive(false);
            isPlayerInRange = false;
        }
    }

    IEnumerator ShowTalkMessage()
    {
        if (InteractionText != null)
        {
            InteractionPanel.SetActive(true);
            yield return new WaitForSeconds(2f);
            InteractionPanel.SetActive(false);
        }
    }
    IEnumerator ResetTalkOpenState()
    {
        yield return new WaitForSeconds(2.5f);
        isTalk = false;
    }
}