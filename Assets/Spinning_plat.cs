using UnityEngine;

public class Spinning_plat : MonoBehaviour
{
    int direction = 1;
    float myAngle = 5;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        const float RateOfSpeed = -300;

        myAngle += RateOfSpeed * Time.deltaTime * direction;

        transform.rotation = Quaternion.Euler(0, 0, myAngle);
    }
}
