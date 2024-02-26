
public class EnemyIdleState : EnemyBaseState
{
    
    public EnemyIdleState(EnemyStateMachine enemyStateMachine, EnemyMovement enemyMovement) : base(enemyStateMachine,enemyMovement)
    {
    }

    public override void Enter()
    {
        //StateMachine.Animator.CrossFadeInFixedTime(EnemyAnimationsNames.IdleAnim,0.1f);
    }

    public override void Tick(float deltaTime)
    {
        stateMachine.Animator.SetFloat("Blend", 0,0.1f,deltaTime);
        if (IsPlayerInRange(stateMachine.transform))
        {
            stateMachine.SwitchState(new EnemyChasingState(stateMachine,enemyMovement));
        }
    }

    public override void Exit()
    {
        
    }
}
