using System.Collections;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] GameObject attackPoint;
    [SerializeField] float cooldown = 1f;
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
}
