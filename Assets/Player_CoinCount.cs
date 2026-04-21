using UnityEngine;

public class Player_CoinCount : MonoBehaviour
{
    public float Money;
    public delegate void MoneyChangedHandler(float newcoin, float ammountChanged);
    public event MoneyChangedHandler OnMoneyChanged;
    public Player_Health HealthComp;


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
            if (Money == 10)
            {
                Money = Money - 10;
                HealthComp.AddHealth(10);

            }
            OnMoneyChanged?.Invoke(Money, coin);
        }
    }
}
