
public abstract class PlayerBaseState : State
{
    protected PlayerStateMachine stateMachine;
    protected PlayerMovement playerMovement;

    public PlayerBaseState(PlayerStateMachine stateMachine,PlayerMovement playerMovement)
    {
        this.stateMachine = stateMachine;
        this.playerMovement = playerMovement;
    }

}
