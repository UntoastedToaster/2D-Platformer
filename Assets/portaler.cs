using Unity.VisualScripting;
using UnityEngine;

public class portaler : MonoBehaviour
{
    public Transform targetLocation;
 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.transform.position = targetLocation.transform.position;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(targetLocation.position, 0.25f);
    }
}
