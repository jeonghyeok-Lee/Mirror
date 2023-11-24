using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float sprintSpeed = 1.4f;
    public float walkSpeed = 0.6f;
    public float crouchSpeed = 0.3f;
    public float normalSpeed = 3f;
    public bool isGround = false;
    public LayerMask whatIsGround;
    public float playerHeight = 1f;
    public float jumpForce = 8f;
    private PlayerInputHandler input;
    private float changedSpeed = 1f;
    private CharacterController charCtrl;
    Vector3 direction;
    float terminalVelocity = 55f;
    public float jumpTimeout = .1f;
    public float fallTimeout = .15f;
    float verticalVelocity;
    // timeout deltatime
    private float jumpTimeoutDelta;
    private float fallTimeoutDelta;


    private Rigidbody rb;
    public enum MovementState
    {
        idle,
        normal,
        walking,
        sprinting,
        crouching,
        air
    }

    public MovementState state;

    private void Awake()
    {
        TryGetComponent(out input);
        TryGetComponent(out charCtrl);
        TryGetComponent(out rb);
    }

    private void Start()
    {
        jumpTimeoutDelta = jumpTimeout;
        fallTimeoutDelta = fallTimeout;
    }

    private void Update()
    {
        OnGround();
        Movement();
        StateHandler();
    }

    private void FixedUpdate()
    {
        MovementPlayer();
        MovementPlayerJump();
        MovementPlayerGravity();
    }

    private void OnGround()
    {
        isGround = Physics.Raycast(transform.position, Vector3.down, 0.3f, whatIsGround);
    }

    private void Movement()
    {
        direction = gameObject.transform.forward * input.move.y + gameObject.transform.right * input.move.x;

        direction *= changedSpeed * normalSpeed;
        direction.y = verticalVelocity;
    }

    private void MovementPlayer()
    {
        charCtrl.Move(direction * Time.deltaTime);
    }

    private void MovementPlayerJump()
    {
        if (isGround)
        {
            fallTimeoutDelta = fallTimeout;

            if (verticalVelocity < 0f)
            {
                verticalVelocity = -2f;
            }

            if (input.isJump && jumpTimeoutDelta <= 0f)
            {
                verticalVelocity = Mathf.Sqrt(jumpForce * -2f * -9.81f);
            }

            if (jumpTimeoutDelta >= 0f)
            {
                jumpTimeoutDelta -= Time.deltaTime;
            }
        }
        else
        {
            jumpTimeoutDelta = jumpTimeout;

            if (fallTimeoutDelta >= 0f)
            {
                fallTimeoutDelta -= Time.deltaTime;
            }
        }
    }
    private void MovementPlayerGravity()
    {
        if (verticalVelocity < terminalVelocity)
        {
            verticalVelocity += -9.81f * rb.mass * rb.drag * Time.deltaTime;
        }
    }
    private void StateHandler()
    {
        if (input.isWalk)
        {
            state = MovementState.walking;
            changedSpeed = walkSpeed;
        }
        else if (input.isSprint)
        {
            state = MovementState.sprinting;
            changedSpeed = sprintSpeed;
        }
        else if (input.isCrouch)
        {
            state = MovementState.crouching;
            changedSpeed = crouchSpeed;
        }
        else if (isGround)
        {
            state = MovementState.normal;
            changedSpeed = 1f;
        }
        else
        {
            state = MovementState.air;
        }
    }
}
