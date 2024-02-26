using System;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

public class EnemyStateMachine : StateMachine
{
    public NavMeshAgent Agent;
    public Animator Animator;
    public GameObject Player;

    public float MovementSpeed;
    
    [FormerlySerializedAs("PlayerChaseDistance")] public float PlayerChaseRange;
    
    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");

        Agent.updatePosition = false;
        Agent.updateRotation = false;
        
        SwitchState(new EnemyIdleState(this));
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position,PlayerChaseRange);
    }
}
