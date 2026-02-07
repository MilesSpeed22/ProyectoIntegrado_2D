using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float speed = 2f;
    [SerializeField] float attackRange;
    [SerializeField] GameObject player;
    [SerializeField] GameObject enemyBody;
    [SerializeField] EnemyAttack enemyAttack;
    [SerializeField] Transform playerRange;
    bool playerDetect;
    [SerializeField] Animator anim;
    public bool isFacingRight = true;

    private void Awake()
    {

    }
    void Update()
    {
        if (!playerDetect)
        {
            anim.SetBool("Walk", false);
            return;
        }

        if (enemyAttack.isStunned)
        {
            anim.SetBool("Walk", false);
            return;
        }

        float distance = Vector2.Distance(enemyBody.transform.position, player.transform.position);

        enemyAttack.canAttack = distance <= attackRange;

        float direction = player.transform.position.x - enemyBody.transform.position.x;

        if (direction > 0 && isFacingRight) Flip();
        else if (direction < 0 && !isFacingRight) Flip();

        if (distance > attackRange)
        {
            FollowPlayer();
            anim.SetBool("Walk", true);
        }
        else anim.SetBool("Walk", false);
    }

    void FollowPlayer()
    {
        enemyBody.transform.position = Vector2.MoveTowards(enemyBody.transform.position, player.transform.position, speed * Time.deltaTime);
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

    void Flip()
    {
        isFacingRight = !isFacingRight;

        Vector3 scale = enemyBody.transform.localScale;
        scale.x *= -1;
        enemyBody.transform.localScale = scale;
    }
}
