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

    public PlayerAttackState(PlayerStateMachine stateMachine,PlayerMovement playerMovement) : base(stateMachine,playerMovement)
    {
    }

    private CombatAnimationData currentAnimation;
    private float currentAnimationNormalizeDuration;
    public override void Enter()
    {
        attackAnimationsDurations = new List<float>(new float[stateMachine.datas.animationClips.GetCombatAnimationData().Count]);
        SetAnimationDurationDatas();
        Debug.Log("onur total anims" + attackAnimationsDurations.Count);
        
        
        attackTimeLimit = 0;
        
        
        stateMachine.PlayerInput.OnDodgeInput += OnDodge;
        
        stateMachine.animator.CrossFadeInFixedTime(
            stateMachine.datas.animationClips.GetCurrentCombatAnimationName(stateMachine.combatData.CurrentCombatIndex),
            0.5f);
        
        currentAnimation =
            stateMachine.datas.animationClips.GetCombatAnimationData()[stateMachine.combatData.CurrentCombatIndex];
        currentAnimationNormalizeDuration =
            (currentAnimation.animation.averageDuration / currentAnimation.animationSpeed) - currentAnimation.animationDurationOffset;
        
        nextComboBreak = 0;
        
        stateMachine.combatData.CurrentCombatIndex++;
        
        if(stateMachine.combatData.CurrentCombatIndex >= stateMachine.comboDatas.AttackComboNamesList.Count)
        {
            stateMachine.combatData.CurrentCombatIndex = 0;
        }
        
        
        Debug.Log("onur index " + stateMachine.combatData.CurrentCombatIndex);
        playerMovement.AttackMovement(stateMachine.transform,0.4f,stateMachine.her);
    }
    
    public override void Tick(float deltaTime)
    {
        
        //ATTACK animasyonundan sonra 0.2-0.3 gibi bi aralıkda combo atağın devamını yapabilmeliyiz, şuan o düzgün değil
        attackTimeLimit += Time.deltaTime;
        
        Debug.Log("onur index " + stateMachine.combatData.CurrentCombatIndex);
        Debug.Log("onur currentAnimation duration " + currentAnimationNormalizeDuration);
        
        if(attackTimeLimit > currentAnimationNormalizeDuration) 
        {
            nextComboBreak += Time.deltaTime;
            
            //Make combo continue
            if(stateMachine.PlayerInput.playerActions.PlayerControls.Fire.triggered) 
            {
                stateMachine.SwitchState(new PlayerAttackState(stateMachine,playerMovement));
            }
            
            //After current combo animation played, if player does not want to continue combo walk instead
            if (stateMachine.PlayerInput.playerActions.PlayerControls.Movement.triggered)
            {
                stateMachine.SwitchState(new PlayerMovementState(stateMachine,playerMovement));
            }
            
            //Player can continue his combo after a while later(currently 0.5)
            if (nextComboBreak >= 0.5f)
            {
                Debug.Log("here");
                
                stateMachine.combatData.CurrentCombatIndex = 0;
                //After current combo finished, if player holds wasd or gamepad stick inputs, can walk
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
