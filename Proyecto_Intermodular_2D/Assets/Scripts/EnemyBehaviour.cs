using System.Collections;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float health = 2f;
    [SerializeField] bool canAttack;
    [SerializeField] GameObject attackPoint;
    

    private void Awake()
    {
        canAttack = true;
        EnemyMovement enemyMovement = new EnemyMovement();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Attack());
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Attack"))
        {
            health -= 1f;

            if (health <= 0)
            {
                gameObject.SetActive(false);
            }
        }
    }
    IEnumerator Attack()
    {
        canAttack = false;

        attackPoint.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        attackPoint.SetActive(false);

        yield return new WaitForSeconds(0.2f);
        canAttack = true;
    }

    
}
