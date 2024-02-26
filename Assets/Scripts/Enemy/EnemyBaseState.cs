
using UnityEngine;

public abstract class EnemyBaseState : State
{
    protected EnemyStateMachine StateMachine;

    protected EnemyBaseState(EnemyStateMachine enemyStateMachine)
    {
        StateMachine = enemyStateMachine;
    }

    protected bool IsPlayerInRange(Transform transform)
    {
        float distance = (transform.position - StateMachine.Player.transform.position).magnitude;
        return distance <= StateMachine.PlayerChaseRange;
    }
}
