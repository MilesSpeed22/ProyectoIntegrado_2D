using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] float cooldown = 1f;
    public bool canAttack;
    public bool isAttacking;
    public bool isStunned;
    Animator anim;
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
        canAttack = false;
        anim.SetTrigger("Attack");

        yield return new WaitForSeconds(cooldown);
        isAttacking = false;
        canAttack = true;
    }
    public void OnHit()
    {
        if (isStunned) return;

        isStunned = true;
        isAttacking = false;
        canAttack = false;

        StopAllCoroutines();
        anim.SetTrigger("Damage");

        StartCoroutine(HitStun());
    }


    IEnumerator HitStun()
    {

        //animacion pa luego
        yield return new WaitForSeconds(hitStunTime);
        isStunned = false;

    }
}
