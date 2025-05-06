using System.Collections;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.UI;

public class N_ElfEvent : MonoBehaviour
{

    private bool IsTalk = false;
    private bool IsPlayerInRange = false;

    public GameObject KeyPanel; // ��ȣ�ۿ� �ϰڳİ� ���� �ǳ�
    public Text KeyText;

    public GameObject InteractionPanel; //NPC�� ��簡 ��µǴ� �ǳ�
    public Text InteractionText;

    void Update()
    {
        if (IsPlayerInRange && !IsTalk)
        {
            KeyPanel.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
            {
                KeyPanel.SetActive(false);
                IsTalk = true;
                StartCoroutine(ShowTalkMessage());
                StartCoroutine(ResetTalkOpenState());
            }
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
        IsTalk = false;
    }
}