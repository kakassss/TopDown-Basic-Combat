
public class EnemyIdleState : EnemyBaseState
{
    
    public EnemyIdleState(EnemyStateMachine enemyStateMachine) : base(enemyStateMachine)
    {
    }

    public override void Enter()
    {
        StateMachine.Animator.CrossFadeInFixedTime(EnemyAnimationsNames.IdleAnim,0.1f);
    }

    public override void Tick(float deltaTime)
    {
        IsPlayerInRange(StateMachine.transform);
    }

    public override void Exit()
    {
        
    }
}
