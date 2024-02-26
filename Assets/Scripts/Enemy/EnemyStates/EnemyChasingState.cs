
using System;
using UnityEngine;

public class EnemyChasingState : EnemyBaseState
{
    private float dampTime = 0.1f;
    
    public EnemyChasingState(EnemyStateMachine enemyStateMachine) : base(enemyStateMachine)
    {
    }

    public override void Enter()
    {
        StateMachine.Animator.SetFloat("Blend", 0.1f);
        //StateMachine.Animator.CrossFadeInFixedTime(EnemyAnimationsNames.RunAnim,0.1f);
    }

    public override void Tick(float deltaTime)
    {
        
        StateMachine.Animator.SetFloat("Blend", 1,dampTime,deltaTime);
        if (IsPlayerInRange(StateMachine.transform) == false)
        {
            StateMachine.SwitchState(new EnemyIdleState(StateMachine));
        }
    }

    public override void Exit()
    {
       
    }

    private void MoveToPlayer()
    {
        
    }
}
