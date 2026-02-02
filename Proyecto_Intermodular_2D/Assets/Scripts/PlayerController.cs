using System.Collections;
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

    [Header ("Prototype")]
    public GameObject attackPoint;
    [SerializeField] float attackCooldown;
    private void Awake()
    {
       PlayerRb = GetComponent<Rigidbody2D>();
       input = GetComponent<PlayerInput>();
       canAttack = true;
    }
    void Start()
    {
        
    }

    void Update()
    {
        //if (moveInput.x > 0 && !isFacingRight) transform.localScale.x = 1;
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
        canAttack = true;

        attackPoint.SetActive(true);//Aqui animacion de pegar para luego
        yield return new WaitForSeconds(0.1f); 
        attackPoint.SetActive(false);
        yield return new WaitForSeconds(attackCooldown);
        
        canAttack = false;


    }

    //Ataque para cuando tenga animacion
    //IEnumerator Attack()
    //{
     //   canAttack = false; //Quitar la posibilidad de atacar        
      //  float actualSpeed = speed; //Guardamos la velocidad actual para devolverla luego
      //  speed = 0; //velocidad 0 el personaje esta quieto
      //  anim.SetTrigger("Attack");
      //  yield return new WaitForSeconds(0.8f);
    //Devolvemos velocidad y capacidad de ataque al jugador
      //  speed = actualSpeed;
       // canAttack = true;
      //  yield return null;


   // }



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
