using UnityEngine;

public class NPCElfEvent : MonoBehaviour
{

    public string ElfMes1 = "�ȳ��ϼ���?"; 

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        { 
            Debug.Log(ElfMes1); 
        }
    }
}