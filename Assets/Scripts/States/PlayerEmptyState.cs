using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEmptyState : PlayerBaseState
{
    public PlayerEmptyState(PlayerStateMachine stateMachine,PlayerMovement playerMovement) : base(stateMachine,playerMovement)
    {
    }

    public override void Enter()
    {
    }

    public override void Tick(float deltaTime)
    {
    }

    public override void Exit()
    {
    }

    

   
}
