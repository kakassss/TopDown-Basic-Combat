using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttackState : PlayerBaseState
{
    private List<float> attacksAnimationTimes;
    private float attack1AnimationTime;
    private float attack2AnimationTime;

    private float attackTimeLimit;
    private float nextComboBreak;
    
    //private int currentCombatIndex = 0;
    public PlayerAttackState(PlayerStateMachine stateMachine,PlayerMovement playerMovement) : base(stateMachine,playerMovement)
    {
    }

    private float currentNormalizedTime;
    public override void Enter()
    {
        attacksAnimationTimes = new List<float>(new float[stateMachine.datas.animationClips.GetCombatAnimationData().Count]);
        SetAnimationDurationDatas();
        Debug.Log("onur total anims" + attacksAnimationTimes.Count);
        //attack2AnimationTime = stateMachine.datas.animationClips.Attack2Animation.averageDuration;
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
        
        if(stateMachine.combatData.CurrentCombatIndex >= stateMachine.comboDatas.AttackComboNamesList.Count)
        {
            stateMachine.combatData.CurrentCombatIndex = 0;
        }
        Debug.Log("onur current animation duration " + attacksAnimationTimes[stateMachine.combatData.CurrentCombatIndex]);

        attackTimeLimit += Time.deltaTime;
        //attacksAnimationTimes[stateMachine.combatData.CurrentCombatIndex]
        if(attackTimeLimit > 1) // animation duration a göre bi şeyler ata yukarda bi şeyler almaya çalıstın
        {
            nextComboBreak += Time.deltaTime;
            
            if(stateMachine.PlayerInput.playerActions.PlayerControls.Fire.triggered) 
            {
                stateMachine.SwitchState(new PlayerAttackState(stateMachine,playerMovement));
            }
            
            if (nextComboBreak >= 0.3f)
            {
                stateMachine.combatData.CurrentCombatIndex = 0; 
                stateMachine.SwitchState(new PlayerIdleState(stateMachine,playerMovement));
            }
        }
    }

    public override void Exit()
    {
        
        
        stateMachine.PlayerInput.OnDodgeInput -= OnDodge;
        //stateMachine.SwitchState(new PlayerIdleState(stateMachine,playerMovement));
    }
    
    private void SetAnimationDurationDatas()
    {
        for (int i = 0; i < attacksAnimationTimes.Count; i++)
        {
            attacksAnimationTimes[i] = stateMachine.datas.animationClips.GetCombatAnimationData()[i].averageDuration;
        }
    }
    
    private void OnDodge()
    {
        stateMachine.combatData.CurrentCombatIndex = 0;
        stateMachine.SwitchState(new PlayerDodgeState(stateMachine,playerMovement));
    }

}
