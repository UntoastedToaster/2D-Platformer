using TMPro;
using UnityEngine;
using System.Collections;
using System;

public class UICoinPanel : MonoBehaviour
{   
    public TextMeshProUGUI coinText;
    public Player_CoinCount playerWealth;
    private float time = 0.9f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerWealth.OnMoneyChanged += OnMoneyChanged;
    }

    // Update is called once per frame
    void Update()
    {
        coinText.color = Color.Lerp(Color.white, Color.white, Mathf.Sin(Time.time)/Time.deltaTime);
    }
    private void OnMoneyChanged(float newcoin, float ammountChanged)
    {
        coinText.text = newcoin.ToString();
        coinText.color = Color.yellow;
        StartCoroutine(BackToWhite(time, ResetColor));
    }

    IEnumerator BackToWhite(float time, Action callback)
    {
        yield return new WaitForSeconds(time);
        callback.Invoke();
    }

    private void ResetColor()
    {
        coinText.color = Color.white;
    }

}
