using UnityEngine;

namespace Enemy
{
    public abstract class EnemyBaseState : State
    {
        protected readonly EnemyStateMachine StateMachine;
        protected readonly EnemyMovement EnemyMovement;

        protected EnemyBaseState(EnemyStateMachine enemyStateMachine,EnemyMovement enemyMovement)
        {
            StateMachine = enemyStateMachine;
            EnemyMovement = enemyMovement;
        }

        protected bool IsPlayerXRange(float range)
        {
            var distance = (StateMachine.transform.position - StateMachine.Player.transform.position).magnitude;
            return distance <= range;
        }

        protected float GetDistanceToPlayer(Transform playerTransform)
        {
            return (playerTransform.position - StateMachine.Player.transform.position).magnitude;
        }
    
        protected void MovementToPlayer(float deltaTime)
        {
            StateMachine.Agent.destination = StateMachine.Player.transform.position;
        
            EnemyMovement.Movement(StateMachine,deltaTime,StateMachine.MovementSpeed / 2);
            EnemyMovement.Rotate(StateMachine,deltaTime,StateMachine.RotateSpeed);
        
        }
    }
}
