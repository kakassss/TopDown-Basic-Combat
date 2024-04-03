
using StateMachines;
using States;

public class PlayerHelperDodgeMovementState : PlayerBaseState
{
    private float dodgingMovementSpeed = 5f;
    private float dodgingRotateSpeed = 6f;
    
    public PlayerHelperDodgeMovementState(PlayerStateMachine stateMachine,PlayerMovement playerMovement) : base(stateMachine,playerMovement)
    {
        
    }

    public override void Enter()
    {
    }

    public override void Tick(float deltaTime)
    {
        PlayerMovement.Movement(deltaTime,StateMachine,dodgingMovementSpeed);
        PlayerMovement.Rotate(deltaTime,StateMachine,dodgingRotateSpeed);
    }

    public override void Exit()
    {

    }

}
