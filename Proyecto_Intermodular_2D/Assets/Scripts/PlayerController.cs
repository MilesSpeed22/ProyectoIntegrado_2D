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
    private void Awake()
    {
       PlayerRb = GetComponent<Rigidbody2D>();
       input = GetComponent<PlayerInput>(); 
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


    #region Input Methods


    public void onMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    private void onAttack()
    {

    }

    #endregion
}
