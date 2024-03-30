
namespace Enemy.EnemyStates
{
    public class EnemyIdleState : EnemyBaseState
    {
    
        public EnemyIdleState(EnemyStateMachine enemyStateMachine, EnemyMovement enemyMovement) : base(enemyStateMachine,enemyMovement)
        {
        }

        public override void Enter()
        {
        
        }

        public override void Tick(float deltaTime)
        {
            EnemyStateMachine.EnemyData.Animator.SetFloat(EnemyAnimationsNames.IdleToRunBlend, 0,0.1f,deltaTime);
        
            if (IsPlayerInXRange(EnemyStateMachine.EnemyData.PlayerChaseRange))
            {
                EnemyStateMachine.SwitchState(new EnemyChasingState(EnemyStateMachine,EnemyMovement));
            }
            else if (IsPlayerInXRange(EnemyStateMachine.EnemyData.PlayerObserveRange))
            {
                EnemyStateMachine.SwitchState(new EnemyChaseAndObserveState(EnemyStateMachine,EnemyMovement));
            }
        }

        public override void Exit()
        {
        
        }
    }
}
