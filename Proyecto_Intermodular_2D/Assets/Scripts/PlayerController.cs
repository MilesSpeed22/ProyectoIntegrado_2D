using System.Collections;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed;
    bool canAttack;
    bool isFacingRight;



    Rigidbody2D PlayerRb;
    Vector2 moveInput;
    PlayerInput input;
    public GameObject attackPoint;
    [SerializeField] float attackCooldown;
    Animator anim;
    Rigidbody2D playerRb;
    private void Awake()
    {
       PlayerRb = GetComponent<Rigidbody2D>();
       input = GetComponent<PlayerInput>();
       canAttack = true;
       anim = GetComponent<Animator>();
    }
    void Start()
    {
        isFacingRight = true;
    }

    void Update()
    {
        if (moveInput.x > 0 && !isFacingRight) Flip();
        if (moveInput.x < 0 && isFacingRight) Flip();
        AnimationManagement();
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
        float actualSpeed = speed;
        speed = 0;
        anim.SetTrigger("Attack");
        yield return new WaitForSeconds(attackCooldown);
        speed = actualSpeed;
        canAttack = true;
        yield return null;

     }

    void Flip()
    {
        Vector3 currentScale = transform.localScale;
        currentScale.x *= -1;
        transform.localScale = currentScale;
        isFacingRight = !isFacingRight;
    }

    #region Input Methods


    public void onMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    public void onAttack(InputAction.CallbackContext context)
    {
        if (context.performed && canAttack)
        {
            StartCoroutine(Attack());
        }
    }

    public void AnimationManagement()
    {
        if (moveInput.x != 0 || moveInput.y != 0) anim.SetBool("Walk", true);
        else anim.SetBool("Walk", false);
    }

    #endregion
}
