using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float speed = 2f;
    [SerializeField] float attackRange;
    [SerializeField] GameObject player;
    [SerializeField] GameObject enemyBody;
    [SerializeField] EnemyAttack enemyAttack;
    [SerializeField] Transform playerRange;
    Animator anim;
    bool playerDetect;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        if (!playerDetect) return;
        

        float distance = Vector2.Distance(enemyBody.transform.position, player.transform.position);

        enemyAttack.canAttack = distance <= attackRange;

        if (enemyAttack.isStunned) return;


        if (distance > attackRange)
        {
            FollowPlayer();
            enemyAttack.canAttack = false;

        }
    }

    void FollowPlayer()
    {
        enemyBody.transform.position = Vector2.MoveTowards(enemyBody.transform.position, player.transform.position, speed * Time.deltaTime);
        //anim.SetBool("Walk", true);
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
