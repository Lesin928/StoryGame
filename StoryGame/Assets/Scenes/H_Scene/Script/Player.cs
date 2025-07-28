using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    Rigidbody2D rigidbody2D;
    Vector2 moveInput;

    private bool _isJumping = false;

    [SerializeField]
    private float MoveSpeed = 4f;
    [SerializeField]
    private float JUMP_FORCE = 10f;
    [SerializeField]
    private float SlowSpeed = 2f;

    float CurrentSpeed => IsSlowingDown ? SlowSpeed : MoveSpeed;

    bool IsSlowingDown = false;

    void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rigidbody2D.linearVelocity = new Vector2(moveInput.x * CurrentSpeed, rigidbody2D.linearVelocity.y);
    }

    public void OnMove(InputValue inputValue)
    {
        moveInput = inputValue.Get<Vector2>();
    }

    public void OnWalk(InputValue inputValue)
    {
        IsSlowingDown = inputValue.isPressed;
    }

    public void OnJump(InputValue inputValue)
    {
        if (!_isJumping)
        {
            _isJumping = true;
            rigidbody2D.linearVelocity = new Vector2(rigidbody2D.linearVelocity.x, JUMP_FORCE);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isJumping = false;
        }
    }
}
