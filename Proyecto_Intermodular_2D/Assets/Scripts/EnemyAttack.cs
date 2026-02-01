using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] GameObject attackPoint;
    [SerializeField] float cooldown = 1f;
    public bool canAttack;
    public bool isAttacking;
    
    public bool isStunned;
    [SerializeField] float hitStunTime = 0.3f;

    void Update()
    {
        if (isStunned) return;

        if (canAttack && !isAttacking)
        {
            StartCoroutine(Attack());
        }
    }
    IEnumerator Attack()
    {
        isAttacking = true;
        attackPoint.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        attackPoint.SetActive(false);
        yield return new WaitForSeconds(cooldown);
        isAttacking = false;
    }
    public void OnHit()
    {
        if (isStunned) return;

        isStunned = true;
        isAttacking = false;
        canAttack = false;

        StopAllCoroutines();
        attackPoint.SetActive(false);

        StartCoroutine(HitStun());
    }


    IEnumerator HitStun()
    {

        //animacion pa luego
        yield return new WaitForSeconds(hitStunTime);
        isStunned = false;

    }
}
