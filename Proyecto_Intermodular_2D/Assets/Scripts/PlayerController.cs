using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float health;
    bool canAttack;
    bool isFacingRight;



    Rigidbody2D PlayerRb;
    Vector2 moveInput;
    PlayerInput input;

    [Header ("Prototype")]
    public GameObject attackPoint;
    [SerializeField] float attackCooldown;
    [SerializeField] Transform respawn;
    private void Awake()
    {
       PlayerRb = GetComponent<Rigidbody2D>();
       input = GetComponent<PlayerInput>();
       canAttack = true;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (moveInput.x > 0 && !isFacingRight) Flip();
        //if (moveInput.x < 0 && isFacingRight) Flip();
    }

    private void FixedUpdate()
    {
        Movement();
    }

    void Movement()
    {
        PlayerRb.linearVelocity = new Vector2(moveInput.x * speed, moveInput.y * speed);
    }

    IEnumerator Attack()
    {
        canAttack = false;

        attackPoint.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        attackPoint.SetActive(false);

        yield return new WaitForSeconds(0.5f);
        canAttack = true;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("EnemyAttack"))
        {
            health -= 1f;

            if (health <= 0)
            {
                gameObject.transform.position = respawn.position;
                health = 2f;
            }
        }
    }

    #region Input Methods


    public void onMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    public void onAttack(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            StartCoroutine(Attack());
        }
    }

    #endregion
}
