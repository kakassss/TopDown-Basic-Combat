
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
            Animation_IdleRunBlend(0,deltaTime);
        
            if (IsPlayerInXRange(EnemyStateMachine.EnemyData.PlayerChaseRange))
            {
                EnemyStateMachine.SwitchState(new EnemyChasingState(EnemyStateMachine,EnemyMovement));
            }
            else if (IsPlayerInXRange(EnemyStateMachine.EnemyData.PlayerObserveRange))
            {
                EnemyStateMachine.SwitchState(new EnemyObserveState(EnemyStateMachine,EnemyMovement));
            }
        }

        public override void Exit()
        {
        
        }
    }
}
