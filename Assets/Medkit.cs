using UnityEngine;

public class Medkit : MonoBehaviour
{
    public float heal = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.GetComponent<Player_Health>().AddHealth(heal);
        Destroy(gameObject);
    }
}
