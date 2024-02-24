using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine : StateMachine
{
    public Animator Animator;
    
    private void Start()
    {
        SwitchState(new EnemyIdleState(this));
    }
}
