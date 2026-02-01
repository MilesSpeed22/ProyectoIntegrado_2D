using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float speed = 2f;
    [SerializeField] float attackRange;
    [SerializeField] GameObject player;
    [SerializeField] EnemyAttack enemyAttack;
    [SerializeField] GameObject healthBar;
    [SerializeField] float healthBarRange;
    bool playerDetect;

    void Update()
    {
        if (!playerDetect) return;
        

        float distance = Vector2.Distance(transform.position, player.transform.position);

        enemyAttack.canAttack = distance <= attackRange;

        if (enemyAttack.isStunned) return;


        if (distance > attackRange)
        {
            FollowPlayer();
            enemyAttack.canAttack = false;
            healthBar.SetActive(false);

        }
        else
        {
            healthBar.SetActive(true);
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
