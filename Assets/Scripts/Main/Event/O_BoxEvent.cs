using System.Collections;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.UI;

public class O_BoxEvent : MonoBehaviour
{
    public GameObject oBox;

    private AnimationHandler animationHandler;

    private bool IsOpened = false;
    private bool IsPlayerInRange = false;

    public GameObject KeyPanel; // 상호작용 하겠냐고 묻는 판넬
    public Text KeyText;

    public GameObject InteractionPanel; //NPC의 대사가 출력되는 판넬
    public Text InteractionText;

    private void Awake()
    {
        if (oBox != null)
        {
            animationHandler = oBox.transform.Find("MainSprite").GetComponent<AnimationHandler>();
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            animationHandler.IsBoxOpen();
        }

        if (IsPlayerInRange && !IsOpened)
        {

            KeyPanel.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
            {
                KeyPanel.SetActive(false);
                IsOpened = true;
                animationHandler.IsBoxOpen();
                StartCoroutine(ShowBoxMessage());
                StartCoroutine(ResetBoxOpenState());

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

    IEnumerator ShowBoxMessage()
    {
        if (InteractionText != null)
        {
            InteractionPanel.SetActive(true);
            yield return new WaitForSeconds(2f);
            InteractionPanel.SetActive(false);
        }
    }
    IEnumerator ResetBoxOpenState()
    {
        yield return new WaitForSeconds(2.5f);
        IsOpened = false;
        animationHandler.IsBoxClose();
    }
}
