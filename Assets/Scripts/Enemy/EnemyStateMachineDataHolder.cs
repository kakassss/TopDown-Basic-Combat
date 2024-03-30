using UnityEngine;
using UnityEngine.AI;

namespace Enemy
{
    public class EnemyStateMachineDataHolder : MonoBehaviour
    { 
        public NavMeshAgent Agent;
        public Animator Animator;

        public float MovementSpeed;
        public float RotateSpeed;
    
        public float PlayerChaseRange;
        public float PlayerObserveRange;
        
        [HideInInspector] public GameObject Player;
        [HideInInspector] public Transform EnemyInitPosition;
        
        public EnemyMovement enemyMovement;
        private void Awake()
        {
            EnemyInitPosition = transform;
            
            enemyMovement = new EnemyMovement();
            Player = GameObject.FindGameObjectWithTag("Player");
            Agent.updatePosition = false;
            Agent.updateRotation = false;
        }
    }
}
