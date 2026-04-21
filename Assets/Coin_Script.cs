using UnityEngine;

public class Coin_Script : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float value = 1;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.GetComponent<Player_CoinCount>().AddCoin(value);
        Destroy(gameObject);
        
    }
}
