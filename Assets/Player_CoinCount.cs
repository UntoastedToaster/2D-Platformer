using UnityEngine;

public class Player_CoinCount : MonoBehaviour
{
    public float Money;
    public delegate void MoneyChangedHandler(float newcoin, float ammountChanged);
    public event MoneyChangedHandler OnMoneyChanged;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Money = 0;
    }

    // Update is called once per frame
    void Update()
    {
     
    }

    public void AddCoin(float coin)
    {
      
        {
            Money += coin;
            OnMoneyChanged?.Invoke(Money, coin);
        }
    }
}
