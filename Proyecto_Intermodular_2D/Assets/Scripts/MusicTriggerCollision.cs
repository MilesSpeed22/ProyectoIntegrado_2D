using UnityEngine;

public class MusicTriggerCollision : MonoBehaviour
{
        [SerializeField] int musicToPlay;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            AudioManager.Instance.PlayMusic(musicToPlay);
        }
    }
}
