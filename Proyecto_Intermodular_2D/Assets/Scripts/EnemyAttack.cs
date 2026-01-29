using System.Collections;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] GameObject attackPoint;
    [SerializeField] float cooldown = 1f;
    [SerializeField] float health;
    public bool canAttack;
    public bool isAttacking;

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



        attackPoint.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        attackPoint.SetActive(false);


        yield return new WaitForSeconds(cooldown);


        attackPoint.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        attackPoint.SetActive(false);
        yield return new WaitForSeconds(cooldown);

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
