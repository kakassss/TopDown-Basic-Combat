
public abstract class EnemyBaseState : State
{
    protected EnemyStateMachine StateMachine;

    protected EnemyBaseState(EnemyStateMachine enemyStateMachine)
    {
        StateMachine = enemyStateMachine;
    }
}
