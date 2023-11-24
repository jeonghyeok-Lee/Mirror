using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerInputHandler : MonoBehaviour
{
    private GameControls gameActions;
    public Vector2 move;
    public Vector2 look;
    public bool isJump = false;
    public bool isWalk = false;
    public bool isSprint = false;
    public bool isCrouch = false;

    Vector2 velo = Vector2.zero;
    private void Awake()
    {
        gameActions = new GameControls();

    }
    void OnEnable()
    {
        gameActions.Player.Enable();
        gameActions.Player.Movement.canceled += DoMovement;
        gameActions.Player.Jump.performed += DoJump;
        gameActions.Player.Sprint.performed += DoSprint;
        gameActions.Player.Walk.performed += DoWalk;
        gameActions.Player.Crouch.performed += DoCrouch;
    }
    void OnDisable()
    {
        gameActions.Player.Movement.canceled += DoMovement;
        gameActions.Player.Jump.performed += DoJump;
        gameActions.Player.Sprint.performed += DoSprint;
        gameActions.Player.Walk.performed += DoWalk;
        gameActions.Player.Crouch.performed += DoCrouch;
        gameActions.Player.Disable();
    }

    private void Update()
    {
        MouseMovement();
        Movement();
        isJump = gameActions.Player.Jump.IsPressed();
        isWalk = gameActions.Player.Walk.IsPressed();
        isCrouch = gameActions.Player.Crouch.IsPressed();
        isSprint = gameActions.Player.Sprint.IsPressed();
    }

    private void MouseMovement()
    {
        look = gameActions.Player.Look.ReadValue<Vector2>();
    }

    private void Movement()
    {
        move = Vector2.SmoothDamp(move, gameActions.Player.Movement.ReadValue<Vector2>(), ref velo, .1f);
    }

    private void DoMovement(InputAction.CallbackContext obj)
    {

    }
    private void DoJump(InputAction.CallbackContext obj)
    {
    }
    private void DoSprint(InputAction.CallbackContext obj)
    {
    }
    private void DoCrouch(InputAction.CallbackContext obj)
    {
    }
    private void DoWalk(InputAction.CallbackContext obj)
    {
    }



}
