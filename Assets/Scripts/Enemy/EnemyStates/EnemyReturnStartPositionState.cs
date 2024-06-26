
using UnityEngine;

namespace EnemyStates.EnemyStates
{
    public class EnemyReturnStartPositionState : EnemyBaseState
    {
        private Transform _initPosition;
        public EnemyReturnStartPositionState(EnemyStateMachine enemyStateMachine, EnemyMovement enemyMovement) : base(enemyStateMachine, enemyMovement)
        {
        }

        public override void Enter()
        {
        }

        
        public override void Tick(float deltaTime)
        {
            if (GetTargetDistanceValue(EnemyStateMachine.EnemyData.EnemyInitPosition) >= 0.1f)
            {
                Animation_IdleRunBlend(0.5f,deltaTime);
                MovementToTarget(EnemyStateMachine.EnemyData.EnemyInitPosition,deltaTime);
                RotateToTarget(EnemyStateMachine.EnemyData.EnemyInitPosition, deltaTime);
            }
            else
            {
                 EnemyStateMachine.SwitchState(new EnemyIdleState(EnemyStateMachine,EnemyMovement));
            }
        }

        public override void Exit()
        {
            
        }
        
    }
}
