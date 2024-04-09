using Enemy.EnemyStates;

namespace EnemyStates.EnemyStates
{
    public class EnemyIdleState : EnemyBaseState
    {
        private EventBinding<EnemyTakenDamageEvent> _enemyTakenDamage;
        
        public EnemyIdleState(EnemyStateMachine enemyStateMachine, EnemyMovement enemyMovement) : base(enemyStateMachine,enemyMovement)
        {
            
        }

        public override void Enter()
        {
            TakenDamageSubscribe();
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
            TakenDamageSubscribe();
        }
        
    }
}
