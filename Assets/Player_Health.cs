using System;
using System.Collections;
using UnityEngine;

public class Player_Health : MonoBehaviour
{
    public float Max_Health = 100;
    private float Health;
    private bool Can_DMG = true;
    public float invincibilityTimer = 2;

    public delegate void HealthChangedHandler(float newhealth,float ammountChanged);
    public event HealthChangedHandler OnHealthChanged;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Health = Max_Health;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddDamage(float damage)
    {
        if (Can_DMG)
        {
            Health -= damage;
            OnHealthChanged?.Invoke(Health, -damage);
            Can_DMG = false;
            StartCoroutine(InvincibilityTimer(invincibilityTimer, ResetInvincibility));
        }
        Debug.Log(Health);
    }

    IEnumerator InvincibilityTimer(float time, Action callback)
    {
        yield return new WaitForSeconds(time);
        callback.Invoke();
    }

    private void ResetInvincibility()
    {
        Can_DMG = true;
        Debug.Log(Can_DMG);

    }
    public void AddHealth(float heal)
    {
        Health += heal;
        OnHealthChanged?.Invoke(Health, heal);
        Debug.Log(Health);


    }

    

    
}
