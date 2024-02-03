using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementState : PlayerBaseState
{
    public PlayerMovementState(PlayerStateMachine stateMachine,PlayerMovement playerMovement) : base(stateMachine,playerMovement)
    {
    }

    public override void Enter()
    {
        //stateMachine.playerInput.OnJumpInput += OnJump;
        stateMachine.PlayerInput.OnDodgeInput += OnDodge;
        stateMachine.PlayerInput.OnAttackLeftInput += OnFire;

        stateMachine.animator.CrossFade("Run",0.2f);
        Debug.Log("Enter Movement");
    }

    public override void Tick(float deltaTime)
    {
        playerMovement.Movement(deltaTime,stateMachine,stateMachine.datas.stats.movementSpeed);
        playerMovement.Rotate(deltaTime,stateMachine,stateMachine.datas.stats.rotateSpeed);

        if(stateMachine.PlayerInput.movementVector == Vector3.zero)
        {
            stateMachine.SwitchState(new PlayerIdleState(stateMachine,playerMovement));
        }
    }

    public override void Exit()
    {
        Debug.Log("Exit Movement");
        //stateMachine.playerInput.OnJumpInput -= OnJump;
        stateMachine.PlayerInput.OnDodgeInput -= OnDodge;
        stateMachine.PlayerInput.OnAttackLeftInput -= OnFire;
    }


    private void OnJump()
    {
        stateMachine.SwitchState(new PlayerJumpState(stateMachine,playerMovement,stateMachine.transform));
    }

    private void OnFire()
    {
        Debug.Log("onur 3333");
        stateMachine.SwitchState(new PlayerAttackState(stateMachine,playerMovement));
    }

    private void OnDodge()
    {
        stateMachine.SwitchState(new PlayerDodgeState(stateMachine,playerMovement));
    }

}
