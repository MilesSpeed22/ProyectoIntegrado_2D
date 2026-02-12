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

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
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
        yield return new WaitForSeconds(cooldown);
        anim.SetTrigger("Attack");
        AudioManager.Instance.PlaySFX(3);
        yield return null;
        float attackDuration = anim.GetCurrentAnimatorStateInfo(0).length;
        yield return new WaitForSeconds(attackDuration);
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
        AudioManager.Instance.PlaySFX(4);

        StartCoroutine(HitStun());
    }


    IEnumerator HitStun()
    {
        yield return new WaitForSeconds(hitStunTime);
        isStunned = false;
        canAttack = true;
    }
}
