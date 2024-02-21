using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttackState : PlayerBaseState
{
    private List<float> attackAnimationsDurations;
    private float attack1AnimationTime;
    private float attack2AnimationTime;

    private float attackTimeLimit;
    private float nextComboBreak;
    
    //private int currentCombatIndex = 0;
    public PlayerAttackState(PlayerStateMachine stateMachine,PlayerMovement playerMovement) : base(stateMachine,playerMovement)
    {
    }

    public override void Enter()
    {
        attackAnimationsDurations = new List<float>(new float[stateMachine.datas.animationClips.GetCombatAnimationData().Count]);
        SetAnimationDurationDatas();
        Debug.Log("onur total anims" + attackAnimationsDurations.Count);
        
        if(stateMachine.combatData.CurrentCombatIndex >= stateMachine.comboDatas.AttackComboNamesList.Count)
        {
            stateMachine.combatData.CurrentCombatIndex = 0;
        }
        attackTimeLimit = 0;
        nextComboBreak = 0;
        
        stateMachine.PlayerInput.OnDodgeInput += OnDodge;
        
        stateMachine.animator.CrossFadeInFixedTime(
            stateMachine.datas.animationClips.GetCurrentCombatAnimationName(stateMachine.combatData.CurrentCombatIndex),
            0.5f);
        
        stateMachine.combatData.CurrentCombatIndex++;
        Debug.Log("onur index " + stateMachine.combatData.CurrentCombatIndex);
        playerMovement.AttackMovement(stateMachine.transform,0.4f,stateMachine.her);
    }
    
    public override void Tick(float deltaTime)
    {
        
        
        //Debug.Log("onur current animation duration " + attackAnimationsDurations[stateMachine.combatData.CurrentCombatIndex]);

        attackTimeLimit += Time.deltaTime;
        var currentAnimation =
            stateMachine.datas.animationClips.GetCombatAnimationData()[stateMachine.combatData.CurrentCombatIndex];
        var currentAnimationNormalizeDuration =
            (currentAnimation.animation.averageDuration / currentAnimation.animationSpeed) - currentAnimation.animationDurationOffset;
        Debug.Log("onur index " + stateMachine.combatData.CurrentCombatIndex);
        Debug.Log("onur currentAnimation duration " + currentAnimationNormalizeDuration);
        
        if(attackTimeLimit > currentAnimationNormalizeDuration) 
        {
            nextComboBreak += Time.deltaTime;
            
            if(stateMachine.PlayerInput.playerActions.PlayerControls.Fire.triggered) 
            {
                Debug.Log("here");
                stateMachine.SwitchState(new PlayerAttackState(stateMachine,playerMovement));
            }
            
            if (nextComboBreak >= 0.3f)
            {
                stateMachine.combatData.CurrentCombatIndex = 0;

                if (stateMachine.PlayerInput.playerActions.PlayerControls.Movement.IsInProgress())
                {
                    stateMachine.SwitchState(new PlayerMovementState(stateMachine,playerMovement));
                }
                else
                {
                    stateMachine.SwitchState(new PlayerIdleState(stateMachine,playerMovement));
                }
            }
        }
    }

    public override void Exit()
    {
        stateMachine.PlayerInput.OnDodgeInput -= OnDodge;
    }
    
    private void SetAnimationDurationDatas()
    {
        for (int i = 0; i < attackAnimationsDurations.Count; i++)
        {
            attackAnimationsDurations[i] = stateMachine.datas.animationClips.GetCombatAnimationData()[i].animation.averageDuration;
        }
    }
    
    private void OnDodge()
    {
        stateMachine.combatData.CurrentCombatIndex = 0;
        stateMachine.SwitchState(new PlayerDodgeState(stateMachine,playerMovement));
    }

}
