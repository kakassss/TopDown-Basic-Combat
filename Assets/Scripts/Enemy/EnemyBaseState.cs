using Enemy;
using Enemy.EnemyStates;
using UnityEngine;

namespace EnemyStates
{
    public abstract class EnemyBaseState : State
    {
        protected readonly EnemyStateMachine EnemyStateMachine;
        protected readonly EnemyMovement EnemyMovement;
        
        private const float DampTime = 0.1f;
        
        private EventBinding<EnemyTakenDamageEvent> _enemyTakenDamage;
        
        protected EnemyBaseState(EnemyStateMachine enemyEnemyStateMachine,EnemyMovement enemyMovement)
        {
            EnemyStateMachine = enemyEnemyStateMachine;
            EnemyMovement = enemyMovement;
        }

        protected void TakenDamageSubscribe()
        {
            _enemyTakenDamage = new EventBinding<EnemyTakenDamageEvent>(OnTakenDamage);
            EventBus<EnemyTakenDamageEvent>.Subscribe(_enemyTakenDamage);
        }

        protected void TakenDamageUnSubscribe()
        {
            EventBus<EnemyTakenDamageEvent>.Unsubscribe(_enemyTakenDamage);
        }

        private void OnTakenDamage()
        {
            EnemyStateMachine.SwitchState(new EnemyTakenDamageState(EnemyStateMachine,EnemyMovement));
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

        protected float GetTargetDistanceValue(Vector3 targetTransform)
        {
            return (targetTransform - EnemyStateMachine.transform.position).magnitude;
        }
    
        protected void MovementAndRotateToPlayer(float deltaTime,float movementSpeedReducer = 1f)
        {
            EnemyStateMachine.EnemyData.Agent.destination = EnemyStateMachine.EnemyData.Player.transform.position;
        
            EnemyMovement.Movement(EnemyStateMachine,deltaTime,EnemyStateMachine.EnemyData.MovementSpeed / movementSpeedReducer);
            EnemyMovement.Rotate(EnemyStateMachine,deltaTime,EnemyStateMachine.EnemyData.RotateSpeed);
        }
        
        protected void MovementToTarget(Vector3 target, float deltaTime,float movementSpeedReducer = 1f)
        {
            EnemyStateMachine.EnemyData.Agent.destination = target;
        
            EnemyMovement.Movement(EnemyStateMachine,deltaTime,EnemyStateMachine.EnemyData.MovementSpeed / movementSpeedReducer);
            EnemyMovement.Rotate(EnemyStateMachine,deltaTime,EnemyStateMachine.EnemyData.RotateSpeed);
        }

        protected void RotateToTarget(Vector3 target,float deltaTime)
        {
            EnemyStateMachine.EnemyData.Agent.destination = target;
            EnemyMovement.Rotate(EnemyStateMachine,deltaTime,EnemyStateMachine.EnemyData.RotateSpeed);
        }
        
        protected void Animation_IdleRunBlend(float animationValue,float deltaTime)
        {
            EnemyStateMachine.EnemyData.Animator.SetFloat(EnemyAnimationsNames.IdleToRunBlend, animationValue,DampTime,deltaTime);
        }
        
        
    }
}
