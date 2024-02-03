using System.Collections;
using System.Collections.Generic;
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
            stateMachine.SwitchState(new PlayerTestState(stateMachine,playerMovement,5));
        }
    }

    public override void Exit()
    {
        Debug.Log("Exit");
    }


}
