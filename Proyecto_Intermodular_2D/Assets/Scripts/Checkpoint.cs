using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("Player")) return;
        
        PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
        if (playerHealth == null ) return;

        playerHealth.SetRespawnPoint(transform);
    }
}
