using System;
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
        public Vector3 EnemyInitPosition;
        
        public EnemyMovement enemyMovement;
        private void Awake()
        {
            
            enemyMovement = new EnemyMovement();
            Player = GameObject.FindGameObjectWithTag("Player");
            Agent.updatePosition = false;
            Agent.updateRotation = false;
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawCube(EnemyInitPosition,Vector3.one);
        }
    }
}
