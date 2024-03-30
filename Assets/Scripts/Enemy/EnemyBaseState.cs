using UnityEngine;

namespace Enemy
{
    public abstract class EnemyBaseState : State
    {
        protected readonly EnemyStateMachine EnemyStateMachine;
        protected readonly EnemyMovement EnemyMovement;

        protected EnemyBaseState(EnemyStateMachine enemyEnemyStateMachine,EnemyMovement enemyMovement)
        {
            EnemyStateMachine = enemyEnemyStateMachine;
            EnemyMovement = enemyMovement;
        }

        protected bool IsPlayerInXRange(float range)
        {
            var distance = (EnemyStateMachine.transform.position - EnemyStateMachine.EnemyData.Player.transform.position).magnitude;
            return distance <= range;
        }

        protected float GetDistanceValueToPlayer(Transform currentEnemyTransform)
        {
            return (currentEnemyTransform.position - EnemyStateMachine.EnemyData.Player.transform.position).magnitude;
        }

        protected float GetTargetDistanceValue(Transform targetTransform)
        {
            //TargetPos - currentEnemy Position
            return (targetTransform.position - EnemyStateMachine.transform.position).magnitude;
        }
    
        protected void MovementToPlayer(float deltaTime,float movementSpeedReducer = 1f)
        {
            EnemyStateMachine.EnemyData.Agent.destination = EnemyStateMachine.EnemyData.Player.transform.position;
        
            EnemyMovement.Movement(EnemyStateMachine,deltaTime,EnemyStateMachine.EnemyData.MovementSpeed / movementSpeedReducer);
            EnemyMovement.Rotate(EnemyStateMachine,deltaTime,EnemyStateMachine.EnemyData.RotateSpeed);
        
        }
    }
}
