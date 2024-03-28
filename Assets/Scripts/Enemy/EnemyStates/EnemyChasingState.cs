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
            StateMachine.Animator.SetFloat(EnemyAnimationsNames.IdleToRunBlend, 0.1f);
        }

        public override void Tick(float deltaTime)
        {
            MovementToPlayer(deltaTime);
            
            StateMachine.Animator.SetFloat(EnemyAnimationsNames.IdleToRunBlend, 1,dampTime,deltaTime);
            if (IsPlayerXRange(StateMachine.PlayerChaseRange) == false)
            {
                StateMachine.SwitchState(new EnemyIdleState(StateMachine,EnemyMovement));
            }
        }

        public override void Exit()
        {
            StateMachine.Agent.ResetPath();
            StateMachine.Agent.velocity = Vector3.zero;
        }
    }
}
