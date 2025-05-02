using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseController : MonoBehaviour
{
    protected Rigidbody2D _rigidbody;
    protected AnimationHandler animationHandler;

    [SerializeField] private SpriteRenderer characterRenderer;

    protected Vector2 movementDirection = Vector2.zero;
    public Vector2 MovementDirection { get { return movementDirection; } }

    protected Vector2 lookDirection = Vector2.zero;
    public Vector2 LookDirection { get { return lookDirection; } }

    private bool isJumpingForward = false; 
    private float jumpDuration = 0.1f; 
    private float jumpTimer = 0f; // 시간 재기용

    private bool isJumpOnCooldown = false; // 점프 쿨타임인지 아닌지
    private float jumpCooldown = 1.0f; // 점프 쿨타임
    private float jumpCooldownTimer = 0f; // 시간 재기용

    private float jumpSpeed = 15f; // 점프의 속도



    protected virtual void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        animationHandler = GetComponent<AnimationHandler>();
        _rigidbody.gravityScale = 0f;
    }

    protected virtual void Start()
    {

    }

    protected virtual void Update()
    {
        HandleAction();
        Rotate(lookDirection);

        if (Input.GetButtonDown("Jump"))
        {
            TryJump();
        }

        if (isJumpOnCooldown)
        {
            jumpCooldownTimer -= Time.deltaTime;
            if (jumpCooldownTimer <= 0f)
            {
                isJumpOnCooldown = false;
            }
        }
    }

    protected virtual void FixedUpdate()
    {
        Vector2 velocity;

        if (isJumpingForward)
        {
            jumpTimer -= Time.fixedDeltaTime;
            if (jumpTimer <= 0f)
            {
                isJumpingForward = false;
            }

            velocity = lookDirection.normalized * jumpSpeed;
        }
        else
        {
            velocity = movementDirection * 5;
        }

        _rigidbody.velocity = velocity;
        animationHandler.Move(new Vector2(velocity.x, 0));
    }

    protected virtual void HandleAction()
    {

    }

    private void TryJump() // 점프를 시도
    {
        if (!isJumpingForward && !isJumpOnCooldown) 
        {
            Jump(); // 점프 이후 값 설정
        }
    }

    private void Jump() // 점프 이후 값 설정
    {
        isJumpingForward = true;
        jumpTimer = jumpDuration;

        isJumpOnCooldown = true; // 현재 점프를 쿨타임으로 설정
        jumpCooldownTimer = jumpCooldown; // 쿨타임 타이머 시작
    }

    private void Movment(Vector2 direction)
    {
        direction = direction * 5;

        _rigidbody.velocity = direction;
        animationHandler.Move(direction);
    }

    private void Rotate(Vector2 direction)
    {
        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        bool isLeft = Mathf.Abs(rotZ) > 90f;

        characterRenderer.flipX = isLeft;
    }
}