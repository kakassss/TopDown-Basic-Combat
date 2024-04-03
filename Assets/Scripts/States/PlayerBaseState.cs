
using StateMachines;

namespace States
{
    public abstract class PlayerBaseState : State
    {
        protected readonly PlayerStateMachine StateMachine;
        protected readonly PlayerMovement PlayerMovement;

        protected PlayerBaseState(PlayerStateMachine stateMachine,PlayerMovement playerMovement)
        {
            this.StateMachine = stateMachine;
            this.PlayerMovement = playerMovement;
        }

        protected bool IsEnemyInAttackRange(float range)
        {
            var distance = (StateMachine.transform.position - StateMachine.Enemy.transform.position).magnitude;

            return distance <= range;
        }
        
    }
}
