using Enemy.EnemyStates;
using StateMachines;
using UnityEngine;
using UnityEngine.AI;

namespace Enemy
{
    public class EnemyStateMachine : StateMachine
    {
        public NavMeshAgent Agent;
        public Animator Animator;
        [HideInInspector] public GameObject Player;

        public float MovementSpeed;
        public float RotateSpeed;
    
        public float PlayerChaseRange;
        public float PlayerObserveRange;

        private EnemyMovement enemyMovement;

        [HideInInspector] public Transform EnemyInitPosition;
    
        private void Start()
        {
            enemyMovement = new EnemyMovement();
            Player = GameObject.FindGameObjectWithTag("Player");

            EnemyInitPosition = transform;
            Agent.updatePosition = false;
            Agent.updateRotation = false;
        
            SwitchState(new EnemyIdleState(this,enemyMovement));
        }
        
        private void OnDrawGizmosSelected()
        {
            //ChaseRange
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position,PlayerChaseRange);
            
            //ObserveRange
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(transform.position,PlayerObserveRange);
        }
        
        
    }
}
