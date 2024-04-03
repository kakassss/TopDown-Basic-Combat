using System;
using StateMachines;
using States;
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
        StateMachine.PlayerInput.OnDodgeInput += OnDodge;
        StateMachine.PlayerInput.OnAttackLeftInput += OnFire;

        StateMachine.animator.CrossFade("Run",0.2f);
        Debug.Log("Enter Movement");
    }

    public override void Tick(float deltaTime)
    {
        PlayerMovement.Movement(deltaTime,StateMachine,StateMachine.datas.stats.movementSpeed);
        PlayerMovement.Rotate(deltaTime,StateMachine,StateMachine.datas.stats.rotateSpeed);

        if(StateMachine.PlayerInput.movementVector == Vector3.zero)
        {
            StateMachine.SwitchState(new PlayerIdleState(StateMachine,PlayerMovement));
        }
    }

    public override void Exit()
    {
        Debug.Log("Exit Movement");
        //stateMachine.playerInput.OnJumpInput -= OnJump;
        StateMachine.PlayerInput.OnDodgeInput -= OnDodge;
        StateMachine.PlayerInput.OnAttackLeftInput -= OnFire;
    }


    private void OnJump()
    {
        StateMachine.SwitchState(new PlayerJumpState(StateMachine,PlayerMovement,StateMachine.transform));
    }

    private void OnFire()
    {
        Debug.Log("onur 3333");
        StateMachine.SwitchState(new PlayerAttackState(StateMachine,PlayerMovement));
    }

    private void OnDodge()
    {
        StateMachine.SwitchState(new PlayerDodgeState(StateMachine,PlayerMovement));
    }

}
