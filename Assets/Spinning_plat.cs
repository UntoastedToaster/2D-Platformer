using UnityEngine;

public class Spinning_plat : MonoBehaviour
{
    int direction = 1;
    float myAngle = 5;
    public float TurnSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        float RateOfSpeed = TurnSpeed;

        myAngle += RateOfSpeed * Time.deltaTime * direction;

        transform.rotation = Quaternion.Euler(0, 0, myAngle);
    }
}
