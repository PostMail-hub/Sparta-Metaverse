using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using TMPro;
using UnityEngine;

public class MG_UIManager : MonoBehaviour
{
    [SerializeField] private GameObject HealthOff1;
    [SerializeField] private GameObject HealthOff2;
    [SerializeField] private GameObject HealthOff3;

    [SerializeField] private GameObject GameOver;

    public void Start()
    {
        GameOver.SetActive(false);
    }

    public void SetRestart()
    {
        GameOver.SetActive(true);
    }


    public void Health1()
    {
        HealthOff1.SetActive(true);
    }
    public void Health2()
    {
        HealthOff2.SetActive(true);
    }
    public void Health3()
    {
        HealthOff3.SetActive(true);
    }
}
