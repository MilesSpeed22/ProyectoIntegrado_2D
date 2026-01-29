using System.Collections;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] GameObject attackPoint;
    [SerializeField] float cooldown = 1f;
    [SerializeField] float health;

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
        canAttack = false;
<<<<<<< Updated upstream

        // Golpe activo
        attackPoint.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        attackPoint.SetActive(false);

        // Espera cooldown
        yield return new WaitForSeconds(cooldown);

=======
        attackPoint.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        attackPoint.SetActive(false);
        yield return new WaitForSeconds(cooldown);
>>>>>>> Stashed changes
        isAttacking = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Attack"))
        {
            health--;
            if (health <= 0)
                gameObject.SetActive(false);
        }
    }
}
