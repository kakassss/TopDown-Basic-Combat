
public class EnemyIdleState : EnemyBaseState
{
    
    public EnemyIdleState(EnemyStateMachine enemyStateMachine) : base(enemyStateMachine)
    {
    }

    public override void Enter()
    {
        StateMachine.Animator.SetFloat("Blend", 0);
        //StateMachine.Animator.CrossFadeInFixedTime(EnemyAnimationsNames.IdleAnim,0.1f);
    }

    public override void Tick(float deltaTime)
    {
        StateMachine.Animator.SetFloat("Blend", 0,0.1f,deltaTime);
        if (IsPlayerInRange(StateMachine.transform))
        {
            StateMachine.SwitchState(new EnemyChasingState(StateMachine));
        }
    }

    public override void Exit()
    {
        
    }
}
