using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [Header("EnemyHealth")]
    [SerializeField] float maxHealth;
    float currentHealth;

    [Header("PlayerUI")]
    [SerializeField] RectTransform healthFill;
    Vector3 originalScale;

    [SerializeField] EnemyAttack enemyAttack;
    void Start()
    {
        currentHealth = maxHealth;
        originalScale = healthFill.localScale;
        UpdateHealthBar();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Attack"))
        {
            Debug.Log("ENEMY HIT");
            EnemyDamage(1);
        }
    }

    void EnemyDamage(float damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        enemyAttack.OnHit();

        UpdateHealthBar();
        if (currentHealth <= 0) gameObject.SetActive(false);
    }

    void UpdateHealthBar()
    {
        float percent = currentHealth / maxHealth;

        healthFill.localScale = new Vector3(originalScale.x * percent, originalScale.y, originalScale.z);
    }
}
