using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float playerHealth;
    [SerializeField] RectTransform healthFill;
    Vector3 originalScale;
    GameManager gameManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        originalScale = healthFill.localScale;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("EnemyAttack"))
        {
            playerHealth -= 1;

            if (playerHealth < 0) SceneManager.LoadScene(0);
        }
    }

}
