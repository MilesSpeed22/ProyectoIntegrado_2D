using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [Header("EnemyHealth")]
    [SerializeField] float maxHealth;
    float currentHealth;

    [Header("PlayerUI")]
    [SerializeField] RectTransform healthFill;
    [SerializeField] GameObject healthBar;
    Vector3 originalScale;
    [SerializeField] GameObject player;
    [SerializeField] float barRange;
    Animator anim;

    [SerializeField] EnemyAttack enemyAttack;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    void Start()
    {
        currentHealth = maxHealth;
        originalScale = healthFill.localScale;
        UpdateHealthBar();
    }

    private void Update()
    {
        float distance = Vector2.Distance(transform.position, player.transform.position);

        if (enemyAttack.isStunned) return;


        if (distance > barRange)
        {
            healthBar.SetActive(false);

        }
        else
        {
            healthBar.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Attack"))
        {
            EnemyDamage(1);
            anim.SetBool("Damage", true);
        }
    }

    void EnemyDamage(float damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        enemyAttack.OnHit();

        UpdateHealthBar();
        if (currentHealth <= 0)
        {
            
            gameObject.SetActive(false);
        }
    }   

    void UpdateHealthBar()
    {
        float percent = currentHealth / maxHealth;

        healthFill.localScale = new Vector3(originalScale.x * percent, originalScale.y, originalScale.z);
    }
}
