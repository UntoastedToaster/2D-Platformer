using JetBrains.Annotations;
using System;
using TMPro;
using UnityEngine;

public class UIHealthDisplay : MonoBehaviour
{
    public TextMeshProUGUI healthText;
    public Player_Health playerHealth;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerHealth.OnHealthChanged += OnHealthChanged;
        playerHealth.OnHealthInit += OnHealthInit;
    }

    private void OnHealthInit(float MaxHP)
    {
        healthText.text = MaxHP.ToString();
    }


    public void OnHealthChanged(float newhealth, float ammountChanged)
    {
        //Debug.Log(":3");
        healthText.text = newhealth.ToString();
    }
}
