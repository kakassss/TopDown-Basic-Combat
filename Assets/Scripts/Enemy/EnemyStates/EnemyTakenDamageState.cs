using EnemyStates;
using UnityEngine;

namespace Enemy.EnemyStates
{
    public class EnemyTakenDamageState : EnemyBaseState
    {
        
        
        public EnemyTakenDamageState(EnemyStateMachine enemyEnemyStateMachine, EnemyMovement enemyMovement) : base(enemyEnemyStateMachine, enemyMovement)
        {

            
        }
        
        public override void Enter()
        {
            Debug.Log("onur asfdadsafx333");
        }

        public override void Tick(float deltaTime)
        {
            EnemyStateMachine.EnemyData.Animator.CrossFadeInFixedTime(EnemyAnimationsNames.DamageTaken,0.1f);
        }

        public override void Exit()
        {
            
        }
    }
}
