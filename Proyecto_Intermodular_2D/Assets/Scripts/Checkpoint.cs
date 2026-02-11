using System.Collections;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] Animator anim;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("Player")) return;

        anim.SetTrigger("Flash");
        PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
        if (playerHealth == null ) return;

        playerHealth.SetRespawnPoint(transform);
    }
}
