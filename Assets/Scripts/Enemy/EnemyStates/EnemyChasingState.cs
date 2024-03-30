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
            EnemyStateMachine.EnemyData.Animator.SetFloat(EnemyAnimationsNames.IdleToRunBlend, 0.1f);
        }

        public override void Tick(float deltaTime)
        {
            MovementToPlayer(deltaTime);
            
            EnemyStateMachine.EnemyData.Animator.SetFloat(EnemyAnimationsNames.IdleToRunBlend, 1,dampTime,deltaTime);
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
