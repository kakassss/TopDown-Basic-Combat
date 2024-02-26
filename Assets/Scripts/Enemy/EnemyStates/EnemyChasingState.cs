
using System;
using UnityEngine;

public class EnemyChasingState : EnemyBaseState
{
    private float blendRunSpeed = 0.1f;
    
    public EnemyChasingState(EnemyStateMachine enemyStateMachine) : base(enemyStateMachine)
    {
    }

    public override void Enter()
    {
        StateMachine.Animator.SetFloat("Blend", blendRunSpeed);
        //StateMachine.Animator.CrossFadeInFixedTime(EnemyAnimationsNames.RunAnim,0.1f);
    }

    public override void Tick(float deltaTime)
    {
        blendRunSpeed += Time.deltaTime;
        blendRunSpeed = Mathf.Clamp(blendRunSpeed, blendRunSpeed, 1);
        
        
        StateMachine.Animator.SetFloat("Blend", blendRunSpeed);
        if (IsPlayerInRange(StateMachine.transform) == false)
        {
            StateMachine.SwitchState(new EnemyIdleState(StateMachine));
        }
    }

    public override void Exit()
    {
       
    }
}
