using UnityEngine;

namespace Enemy.EnemyStates
{
    public class EnemyChasingState : EnemyBaseState
    {
        private float dampTime = 0.1f;
    
        public EnemyChasingState(EnemyStateMachine enemyStateMachine, EnemyMovement enemyMovement) : base(enemyStateMachine,enemyMovement)
        {
        }

        public override void Enter()
        {
            Animation_IdleRunBlend(0.1f,0);
        }

        public override void Tick(float deltaTime)
        {
            MovementAndRotateToPlayer(deltaTime);
            
            Animation_IdleRunBlend(1,deltaTime);
            if (IsPlayerInXRange(EnemyStateMachine.EnemyData.PlayerChaseRange) == false)
            {
                EnemyStateMachine.SwitchState(new EnemyIdleState(EnemyStateMachine,EnemyMovement));
            }
        }

        public override void Exit()
        {
            EnemyStateMachine.EnemyData.Agent.ResetPath();
            EnemyStateMachine.EnemyData.Agent.velocity = Vector3.zero;
        }
    }
}
