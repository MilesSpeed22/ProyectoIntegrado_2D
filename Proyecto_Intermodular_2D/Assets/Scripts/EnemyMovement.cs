using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float speed = 2f;
    [SerializeField] float attackRange = 1.2f;
    [SerializeField] GameObject player;
    [SerializeField] EnemyAttack enemyAttack;

    bool playerDetect;

    void Update()
    {
        if (!playerDetect) return;

        float distance = Vector2.Distance(transform.position, player.transform.position);

        if (distance > attackRange)
        {
            FollowPlayer();
            enemyAttack.canAttack = false;
        }
        else
        {
            if (!enemyAttack.isAttacking)
                enemyAttack.canAttack = true;
        }
    }

    void FollowPlayer()
    {
        transform.position = Vector2.MoveTowards(
            transform.position,
            player.transform.position,
            speed * Time.deltaTime
        );
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            playerDetect = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerDetect = false;
            enemyAttack.canAttack = false;
        }
    }
}
