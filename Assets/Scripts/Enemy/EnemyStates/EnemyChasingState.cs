
using System;
using UnityEngine;

public class EnemyChasingState : EnemyBaseState
{
    private float dampTime = 0.1f;
    
    public EnemyChasingState(EnemyStateMachine enemyStateMachine, EnemyMovement enemyMovement) : base(enemyStateMachine,enemyMovement)
    {
    }

    public override void Enter()
    {
        stateMachine.Animator.SetFloat("Blend", 0.1f);
        //StateMachine.Animator.CrossFadeInFixedTime(EnemyAnimationsNames.RunAnim,0.1f);
    }

    public override void Tick(float deltaTime)
    {
        MovementToPlayer(deltaTime);
        stateMachine.Animator.SetFloat("Blend", 1,dampTime,deltaTime);
        if (IsPlayerInRange(stateMachine.transform) == false)
        {
            stateMachine.SwitchState(new EnemyIdleState(stateMachine,enemyMovement));
        }
    }

    public override void Exit()
    {
       stateMachine.Agent.ResetPath();
       stateMachine.Agent.velocity = Vector3.zero;
    }

    private void MovementToPlayer(float deltaTime)
    {
        stateMachine.Agent.destination = stateMachine.Player.transform.position;
        
        enemyMovement.Movement(stateMachine,deltaTime,stateMachine.MovementSpeed);
        enemyMovement.Rotate(stateMachine,deltaTime,stateMachine.RotateSpeed);
        
    }
}
