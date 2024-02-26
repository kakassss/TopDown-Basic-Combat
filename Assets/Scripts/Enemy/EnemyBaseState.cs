
using UnityEngine;

public abstract class EnemyBaseState : State
{
    protected EnemyStateMachine StateMachine;

    protected EnemyBaseState(EnemyStateMachine enemyStateMachine)
    {
        StateMachine = enemyStateMachine;
    }

    protected void IsPlayerInRange(Transform transform)
    {
        Vector3 distanceVector = transform.position - StateMachine.Player.transform.position;
        var distance = distanceVector.magnitude;

        if (distance <= StateMachine.PlayerChaseRange)
        {
            Debug.LogError("can chase player");
        }
    }
}
