using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] public Transform respawnPoint;
    [Header ("PlayerHealth")]
    [SerializeField] float maxHealth;
    float currentHealth;
    [SerializeField] int lives = 3;
    Animator anim;

    [Header ("PlayerUI")]
    [SerializeField] RectTransform healthFill;
    Vector3 originalScale;

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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("EnemyAttack"))
        {
            PlayerDamage(1);            
        }
    }

    void PlayerDamage(float damage)
    {
        anim.SetTrigger("Damage");
        AudioManager.Instance.PlaySFX(1);
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
            StartCoroutine(GameOver());
            //GameOver();
        }

    }

    private void Respawn()
    {
        transform.position = respawnPoint.position;
        currentHealth = maxHealth;
        UpdateHealthBar();
    }

    //private void GameOver()
    //{
        //SceneManager.LoadScene(4);
    //}

    IEnumerator GameOver()
    {
        anim.SetTrigger("Death");
        AudioManager.Instance.PlaySFX(6);
        yield return new WaitForSeconds(0.8f);
        SceneManager.LoadScene(4);
    }

    void UpdateHealthBar()
    {
        float percent = currentHealth / maxHealth;

        healthFill.localScale = new Vector3(originalScale.x * percent, originalScale.y, originalScale.z);
    }

    public void SetRespawnPoint(Transform newRespawnPoint)
    {
        respawnPoint = newRespawnPoint;
    }

    public void RestoreFullHealth()
    {
        currentHealth = maxHealth;
        UpdateHealthBar();
    }
}
