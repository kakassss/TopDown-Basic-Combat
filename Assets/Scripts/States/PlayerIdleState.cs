
using StateMachines;

namespace States
{
    public class PlayerIdleState : PlayerBaseState
    {
        public PlayerIdleState(PlayerStateMachine stateMachine,PlayerMovement playerMovement) : base(stateMachine,playerMovement)
        {
        }

        public override void Enter()
        {
            StateMachine.PlayerInput.OnMovementInput += OnMovement;
            StateMachine.PlayerInput.OnAttackLeftInput += OnAttackLeftClick;
            StateMachine.PlayerInput.OnDodgeInput += OnDodge;
            StateMachine.animator.CrossFade(PlayerAnimationsNames.IdleAnim,0.1f);
        }

        public override void Tick(float deltaTime)
        {
        
        }

        public override void Exit()
        {
            StateMachine.PlayerInput.OnMovementInput -= OnMovement;
            StateMachine.PlayerInput.OnAttackLeftInput -= OnAttackLeftClick;
            StateMachine.PlayerInput.OnDodgeInput -= OnDodge;
        }

        private void OnMovement()
        {
            StateMachine.SwitchState(new PlayerMovementState(StateMachine,PlayerMovement));
        }

        private void OnAttackLeftClick()
        {
            StateMachine.SwitchState(new PlayerAttackState(StateMachine,PlayerMovement));
        }


        private void OnDodge()
        {
            StateMachine.SwitchState(new PlayerDodgeState(StateMachine,PlayerMovement));
        }
    }
}
