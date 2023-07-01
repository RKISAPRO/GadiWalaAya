using UnityEngine;

public class BagCollision : MonoBehaviour
{
    private const string Player = "Player";

    private void OnCollisionEnter(Collision col) 
    {
        if(col.collider.CompareTag(Player))
        {
            Destroy(gameObject);
        }
    }
}