using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] Transform respawnPoint;
    [Header ("PlayerHealth")]
    [SerializeField] float maxHealth;
    float currentHealth;

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
        if (currentHealth <= 0) transform.position = respawnPoint.position;
    }

    void UpdateHealthBar()
    {
        float percent = currentHealth / maxHealth;

        healthFill.localScale = new Vector3(originalScale.x * percent, originalScale.y, originalScale.z);
    }
}
