using Enemy.EnemyStates;
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

        private EnemyMovement enemyMovement;
    
        private void Start()
        {
            enemyMovement = new EnemyMovement();
            Player = GameObject.FindGameObjectWithTag("Player");

            Agent.updatePosition = false;
            Agent.updateRotation = false;
        
            SwitchState(new EnemyIdleState(this,enemyMovement));
        }


        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position,PlayerChaseRange);
        }
    }
}
