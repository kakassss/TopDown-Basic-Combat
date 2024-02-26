
using UnityEngine;

public abstract class EnemyBaseState : State
{
    protected EnemyStateMachine stateMachine;
    protected EnemyMovement enemyMovement;

    protected EnemyBaseState(EnemyStateMachine enemyStateMachine,EnemyMovement enemyMovement)
    {
        stateMachine = enemyStateMachine;
        this.enemyMovement = enemyMovement;
    }

    protected bool IsPlayerInRange(Transform transform)
    {
        float distance = (transform.position - stateMachine.Player.transform.position).magnitude;
        return distance <= stateMachine.PlayerChaseRange;
    }
}
