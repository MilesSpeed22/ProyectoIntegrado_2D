using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] Transform respawnPoint;
    [Header ("PlayerHealth")]
    [SerializeField] float maxHealth;
    float currentHealth;
    [SerializeField] int lives = 3;

    [Header ("PlayerUI")]
    [SerializeField] RectTransform healthFill;
    Vector3 originalScale;

    void Start()
    {
        currentHealth = maxHealth;
        originalScale = healthFill.localScale;
        UpdateHealthBar();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("EnemyAttack"))
        {
            PlayerDamage(1);            
        }
    }

    void PlayerDamage(float damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateHealthBar();
        if (currentHealth <= 0) Die();
    }

    void Die()
    {
        lives -= 1;

        if (lives > 0)
        {
            Respawn();
        }
        else
        {
            GameOver();
        }

    }

    private void Respawn()
    {
        transform.position = respawnPoint.position;
        currentHealth = maxHealth;
        UpdateHealthBar();
    }

    private void GameOver()
    {
        SceneManager.LoadScene(0);
    }

    void UpdateHealthBar()
    {
        float percent = currentHealth / maxHealth;

        healthFill.localScale = new Vector3(originalScale.x * percent, originalScale.y, originalScale.z);
    }
}
