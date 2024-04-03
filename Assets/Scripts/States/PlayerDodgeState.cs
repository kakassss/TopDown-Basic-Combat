using StateMachines;
using States;
using UnityEngine;

public class PlayerDodgeState : PlayerBaseState
{
    private float animationTime;
    private float dodgeLimit;
    private float dodgeMovementMax = 0.3f;

    
    public PlayerDodgeState(PlayerStateMachine stateMachine,PlayerMovement playerMovement) : base(stateMachine,playerMovement) { }

    public override void Enter()
    {
        StateMachine.animator.CrossFadeInFixedTime("Dodging",0.2f);
        animationTime = StateMachine.datas.animationClips.DodgeAnimation.averageDuration;
        dodgeLimit = 0;


        StateMachine.SwichHelperState(new PlayerHelperDodgeMovementState(StateMachine,PlayerMovement));
    }

    public override void Tick(float deltaTime)
    {
        dodgeLimit += Time.deltaTime;

        DodgeMovement(StateMachine.transform);
        
        if(dodgeLimit >= animationTime - 1.2f)
        {
            StateMachine.SwitchState(new PlayerMovementState(StateMachine,PlayerMovement));
            StateMachine.SwichHelperState(new PlayerEmptyState(StateMachine,PlayerMovement));
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
            PlayerMovement.Dodge(player,10);
            //player.transform.Translate(Vector3.forward * 10 * Time.deltaTime);
        }

    }

}
