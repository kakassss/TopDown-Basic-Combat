using System;
using UnityEngine;
using UnityEngine.Serialization;

public class EnemyStateMachine : StateMachine
{
    public Animator Animator;

    public GameObject Player;
    [FormerlySerializedAs("PlayerChaseDistance")] public float PlayerChaseRange;
    
    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        
        SwitchState(new EnemyIdleState(this));
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position,PlayerChaseRange);
    }
}
