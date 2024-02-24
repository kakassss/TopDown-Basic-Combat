using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBaseState : State
{
    protected EnemyStateMachine StateMachine;

    protected EnemyBaseState(EnemyStateMachine enemyStateMachine)
    {
        StateMachine = enemyStateMachine;
    }
}
