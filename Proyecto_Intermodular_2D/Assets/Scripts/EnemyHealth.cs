using System.Collections;
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
    [SerializeField] Animator anim;

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
            anim.SetTrigger("Damage");
        }
    }

    void EnemyDamage(float damage)
    {
        AudioManager.Instance.PlaySFX(0);
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        enemyAttack.OnHit();

        UpdateHealthBar();
        if (currentHealth <= 0)
        {
            AudioManager.Instance.PlaySFX(2);
            StartCoroutine(Die());
        }
    }   

    IEnumerator Die()
    {
        enemyAttack.enabled = false;
        GetComponent<Collider2D>().enabled = false;
        anim.ResetTrigger("Attack");
        anim.ResetTrigger("Damage");
        anim.SetBool("Walk", false);
        anim.SetTrigger("Death");
        yield return new WaitForSeconds(1.5f);
        gameObject.SetActive(false);
    }

    void UpdateHealthBar()
    {
        float percent = currentHealth / maxHealth;

        healthFill.localScale = new Vector3(originalScale.x * percent, originalScale.y, originalScale.z);
    }
}
