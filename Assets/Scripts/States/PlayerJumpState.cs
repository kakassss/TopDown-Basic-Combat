using System.Collections;
using System.Collections.Generic;
using StateMachines;
using States;
using UnityEngine;

public class PlayerJumpState : PlayerBaseState
{
    private Transform playerTransform;
    public PlayerJumpState(PlayerStateMachine stateMachine,PlayerMovement playerMovement,Transform playerTransform) : base(stateMachine,playerMovement)
    {
        this.playerTransform = playerTransform;
    }

    public override void Enter()
    {
        Debug.Log("Jump Enter");
        playerTransform.position = Vector3.Lerp(playerTransform.position,new Vector3(playerTransform.position.x,5,playerTransform.position.z),5f);

    }
    public override void Tick(float deltaTime)
    {
        if(playerTransform.position.y >= 4)
        {
            StateMachine.SwitchState(new PlayerMovementState(StateMachine,PlayerMovement));
        }
    }

    public override void Exit()
    {
        Debug.Log("Jump Exit");
    }


}
