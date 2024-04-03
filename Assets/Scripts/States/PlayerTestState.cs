using System.Collections;
using System.Collections.Generic;
using StateMachines;
using States;
using UnityEngine;

public class PlayerTestState : PlayerBaseState
{
    private float countDownTime;
    public PlayerTestState(PlayerStateMachine stateMachine,PlayerMovement playerMovement, float countDownTime) : base(stateMachine,playerMovement)
    {
        this.countDownTime = countDownTime;
    }

    public override void Enter()
    {
        Debug.Log("Enter");
    }

    public override void Tick(float deltaTime)
    {
        if(countDownTime > 0)
        {
            countDownTime -= deltaTime;
            Debug.Log("Tick " + countDownTime);
        }
        else
        {
            StateMachine.SwitchState(new PlayerTestState(StateMachine,PlayerMovement,5));
        }
    }

    public override void Exit()
    {
        Debug.Log("Exit");
    }


}
