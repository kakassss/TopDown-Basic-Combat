using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttackState : PlayerBaseState
{
    private float attack1AnimationTime;
    private float attack2AnimationTime;

    private float attackTimeLimit;

    //private int currentCombatIndex = 0;
    public PlayerAttackState(PlayerStateMachine stateMachine,PlayerMovement playerMovement) : base(stateMachine,playerMovement)
    {
    }

    public override void Enter()
    {   
        //attack1AnimationTime = stateMachine.datas.animationClips.Attack1Animation.averageDuration;
        //attack2AnimationTime = stateMachine.datas.animationClips.Attack2Animation.averageDuration;
        attackTimeLimit = 0;

        playerMovement.AttackMovement(stateMachine.transform,1f);
        stateMachine.animator.CrossFadeInFixedTime(
            stateMachine.datas.animationClips.GetCurrentCombatAnimationName(stateMachine.combatData.CurrentCombatIndex),
            0.5f);
        stateMachine.combatData.CurrentCombatIndex++;
        Debug.Log("onur index " + stateMachine.combatData.CurrentCombatIndex);
    }

    

    public override void Tick(float deltaTime)
    {
        attack1AnimationTime += Time.deltaTime;
        var currentNormalizedTime = stateMachine.animator.GetCurrentAnimatorStateInfo(0).normalizedTime;

        if (stateMachine.animator.IsInTransition(0) && Mouse.current.leftButton.wasPressedThisFrame)
        {
            Debug.Log("onur buradsdas.dfçs.");
        }
        if(currentNormalizedTime > 0.8)
        {
            attackTimeLimit += Time.deltaTime;

            
            if(attackTimeLimit < 0.5f)
            {
                if(stateMachine.combatData.CurrentCombatIndex >= stateMachine.comboDatas.AttackComboNamesList.Count)
                {
                    stateMachine.combatData.CurrentCombatIndex = 0;
                } 

                if(Mouse.current.leftButton.wasPressedThisFrame && Gamepad.current.buttonEast.wasPressedThisFrame)
                {
                    Debug.Log("onur 4444");
                    stateMachine.SwitchState(new PlayerAttackState(stateMachine,playerMovement));
                }

            }
            else
            {
                stateMachine.combatData.CurrentCombatIndex = 0; 
                stateMachine.SwitchState(new PlayerIdleState(stateMachine,playerMovement));
            }
            
        }
        Debug.Log("Fire!");
        
    }

    public override void Exit()
    {
          
        Debug.Log("Fire Stop");
        //stateMachine.SwitchState(new PlayerIdleState(stateMachine,playerMovement));
    }

}
