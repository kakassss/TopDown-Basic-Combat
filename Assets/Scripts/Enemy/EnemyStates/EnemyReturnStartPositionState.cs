
using UnityEngine;

namespace Enemy.EnemyStates
{
    public class EnemyReturnStartPositionState : EnemyBaseState
    {
        private Transform _initPosition;
        public EnemyReturnStartPositionState(EnemyStateMachine enemyStateMachine, EnemyMovement enemyMovement) : base(enemyStateMachine, enemyMovement)
        {
        }

        public override void Enter()
        {
            _initPosition = EnemyStateMachine.EnemyData.EnemyInitPosition;
            Debug.Log("onur burda " + _initPosition.position );
        }

        public override void Tick(float deltaTime)
        {
            Debug.Log("onur burda " + GetTargetDistanceValue(_initPosition) );
            if (GetTargetDistanceValue(_initPosition) >= 0.1f)
            {
                EnemyMovement.Rotate(EnemyStateMachine,deltaTime,EnemyStateMachine.EnemyData.RotateSpeed);
                EnemyMovement.Movement(EnemyStateMachine,deltaTime,EnemyStateMachine.EnemyData.MovementSpeed);
            }
            // else
            // {
            //     EnemyStateMachine.SwitchState(new EnemyIdleState(EnemyStateMachine,EnemyMovement));
            // }
            
            
        }

        public override void Exit()
        {
            
        }
    }
}
