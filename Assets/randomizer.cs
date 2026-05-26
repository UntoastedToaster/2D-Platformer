using UnityEngine;

public class randomizer : MonoBehaviour
{
    public float xpos;
    public float ypos;
    public void TeleportFUN()
    {
        xpos = Random.Range(30, 900);
        ypos = Random.Range(25, 460);
        transform.position = new Vector3(xpos, ypos, -1);
        
    }
}
