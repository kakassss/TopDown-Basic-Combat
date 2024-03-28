
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
            StateMachine.Animator.SetFloat(EnemyAnimationsNames.IdleToRunBlend, 0,0.1f,deltaTime);
        
            if (IsPlayerXRange(StateMachine.PlayerChaseRange))
            {
                StateMachine.SwitchState(new EnemyChasingState(StateMachine,EnemyMovement));
            }
            else if (IsPlayerXRange(StateMachine.PlayerObserveRange))
            {
                StateMachine.SwitchState(new EnemyChaseAndObserveState(StateMachine,EnemyMovement));
            }
        }

        public override void Exit()
        {
        
        }
    }
}
