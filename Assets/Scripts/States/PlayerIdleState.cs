using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerIdleState : PlayerBaseState
{
    public PlayerIdleState(PlayerStateMachine stateMachine,PlayerMovement playerMovement) : base(stateMachine,playerMovement)
    {
    }

    public override void Enter()
    {
        stateMachine.PlayerInput.OnMovementInput += OnMovement;
        stateMachine.PlayerInput.OnAttackLeftInput += OnAttackLeftClick;
        stateMachine.PlayerInput.OnDodgeInput += OnDodge;
        stateMachine.animator.CrossFade(PlayerAnimationsNames.IdleAnim,0.1f);
    }

    public override void Tick(float deltaTime)
    {
        
    }

    public override void Exit()
    {
        stateMachine.PlayerInput.OnMovementInput -= OnMovement;
        stateMachine.PlayerInput.OnAttackLeftInput -= OnAttackLeftClick;
        stateMachine.PlayerInput.OnDodgeInput -= OnDodge;
    }

    private void OnMovement()
    {
        stateMachine.SwitchState(new PlayerMovementState(stateMachine,playerMovement));
    }

    private void OnAttackLeftClick()
    {
        stateMachine.SwitchState(new PlayerAttackState(stateMachine,playerMovement));
    }


    private void OnDodge()
    {
        stateMachine.SwitchState(new PlayerDodgeState(stateMachine,playerMovement));
    }
}
