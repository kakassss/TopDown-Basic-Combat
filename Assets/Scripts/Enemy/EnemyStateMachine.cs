using Enemy.EnemyStates;
using StateMachines;
using UnityEngine;

namespace Enemy
{
    public class EnemyStateMachine : StateMachine
    {
        public EnemyStateMachineDataHolder EnemyData;
        
        private void Start()
        {
            SwitchState(new EnemyIdleState(this,EnemyData.enemyMovement));
        }
        
        private void OnDrawGizmosSelected()
        {
            //ChaseRange
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position,EnemyData.PlayerChaseRange);
            
            //ObserveRange
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(transform.position,EnemyData.PlayerObserveRange);
        }
        
        
    }
}
