using System.Collections;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [Header("Attack Settings")]
    [SerializeField] GameObject attackPoint;
    [SerializeField] float cooldown = 1f; // tiempo entre ataques

    [Header("Health")]
    [SerializeField] float health = 2f;

    [HideInInspector] public bool canAttack;
    [HideInInspector] public bool isAttacking;

    void Update()
    {
        if (canAttack && !isAttacking)
        {
            StartCoroutine(Attack());
        }
    }

    IEnumerator Attack()
    {
        isAttacking = true;
        canAttack = false; // evita reiniciar ataque mientras el cooldown no termina

        // Golpe activo
        attackPoint.SetActive(true);
        yield return new WaitForSeconds(0.1f); // duración del golpe
        attackPoint.SetActive(false);

        // Espera cooldown
        yield return new WaitForSeconds(cooldown);

        isAttacking = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Attack"))
        {
            health -= 1f;
            if (health <= 0)
                gameObject.SetActive(false);
        }
    }
}
