using UnityEngine;

public class NPCElfEvent : MonoBehaviour
{

    public string ElfMes1 = "æ»≥Á«œººø‰?"; 

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        { 
            Debug.Log(ElfMes1); 
        }
    }
}