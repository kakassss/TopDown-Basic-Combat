using UnityEngine;

public class PlayerDodgeState : PlayerBaseState
{
    private float animationTime;
    private float dodgeLimit;
    private float dodgeMovementMax = 0.3f;

    
    public PlayerDodgeState(PlayerStateMachine stateMachine,PlayerMovement playerMovement) : base(stateMachine,playerMovement) { }

    public override void Enter()
    {
        stateMachine.animator.CrossFadeInFixedTime("Dodging",0.2f);
        animationTime = stateMachine.datas.animationClips.DodgeAnimation.averageDuration;
        dodgeLimit = 0;


        stateMachine.SwichHelperState(new PlayerHelperDodgeMovementState(stateMachine,playerMovement));
    }

    public override void Tick(float deltaTime)
    {
        dodgeLimit += Time.deltaTime;

        DodgeMovement(stateMachine.transform);
        
        if(dodgeLimit >= animationTime - 1.2f)
        {
            stateMachine.SwitchState(new PlayerMovementState(stateMachine,playerMovement));
            stateMachine.SwichHelperState(new PlayerEmptyState(stateMachine,playerMovement));
        }

    }

    public override void Exit()
    {
        //stateMachine.SwitchState(new PlayerMovementState(stateMachine,stateMachine.transform,stateMachine.rotateSpeed));
    }

    private void DodgeMovement(Transform player)
    {
        if(dodgeLimit < dodgeMovementMax)
        {
            playerMovement.Dodge(player,10);
            //player.transform.Translate(Vector3.forward * 10 * Time.deltaTime);
        }

    }

}
