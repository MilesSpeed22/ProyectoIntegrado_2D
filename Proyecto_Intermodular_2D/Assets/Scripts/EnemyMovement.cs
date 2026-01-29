using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] float speed = 2f;
    [SerializeField] float attackRange = 1.2f;

    [Header("References")]
    [SerializeField] GameObject player;
    [SerializeField] EnemyAttack enemyAttack;

    bool playerDetect;

    void Update()
    {
        if (!playerDetect) return;

        // Calcula distancia al jugador
        float distance = Vector2.Distance(transform.position, player.transform.position);

        if (distance > attackRange)
        {
            // Alejado → se mueve hacia el jugador
            FollowPlayer();
            enemyAttack.canAttack = false;
        }
        else
        {
            // Dentro del rango → permite atacar
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
