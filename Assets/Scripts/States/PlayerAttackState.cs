using System.Collections.Generic;
using PlayerData;
using PlayerStates;
using UnityEngine;

public class PlayerAttackState : PlayerBaseState
{
    private List<float> _attackAnimationsDurations;
    
    private CombatAnimationData _currentAnimation;
    
    private float _currentAnimationNormalizeDuration;
    private float _attack1AnimationTime;
    private float _attack2AnimationTime;

    private float _attackTimeLimit;
    private float _nextComboBreak;
    
    public PlayerAttackState(PlayerStateMachine stateMachine,PlayerMovement playerMovement) : base(stateMachine,playerMovement)
    {
    }

    public override void Enter()
    {
        stateMachine.PlayerInput.OnDodgeInput += OnDodge;
        
        _attackAnimationsDurations = new List<float>(new float[stateMachine.datas.animationClips.GetCombatAnimationData().Count]);
        SetAnimationDurationDatas();
        
        _attackTimeLimit = 0;
        _nextComboBreak = 0;
        
        stateMachine.animator.CrossFadeInFixedTime(
            stateMachine.datas.animationClips.GetCurrentCombatAnimationName(stateMachine.combatData.CurrentCombatIndex),
            0.5f); //TODO: We can change trasitionDuration???
        
        //Get the current Animation combatData
        _currentAnimation =
            stateMachine.datas.animationClips.GetCombatAnimationData()[stateMachine.combatData.CurrentCombatIndex];
        //Get the current combat animation average duration diveded by our value. With this value we find kind of normalize animation duration
        _currentAnimationNormalizeDuration =
            (_currentAnimation.animation.averageDuration / _currentAnimation.animationSpeed) - _currentAnimation.animationDurationOffset;
        
        //Increase current combo count
        stateMachine.combatData.CurrentCombatIndex++;
        
        //Check currentCombo is max or not
        if(stateMachine.combatData.CurrentCombatIndex >= stateMachine.comboDatas.AttackComboNamesList.Count)
        {
            stateMachine.combatData.CurrentCombatIndex = 0;
        }
        
        playerMovement.SetAttackMovementData(stateMachine.transform,0.3f);
    }
    
    public override void Tick(float deltaTime)
    {
        _attackTimeLimit += Time.deltaTime;
        playerMovement.AttackMovement(stateMachine.transform);

        if (!(_attackTimeLimit > _currentAnimationNormalizeDuration)) return;
        
        ComboContinues();
            
        //After current combo animation played, if player does not want to continue combo walk instead
        if (stateMachine.PlayerInput.playerActions.PlayerControls.Movement.triggered)
        {
            stateMachine.SwitchState(new PlayerMovementState(stateMachine,playerMovement));
            stateMachine.combatData.CurrentCombatIndex = 0;
        }
            
        _nextComboBreak += Time.deltaTime;
            
        //Player can continue his combo after a while later(currently 0.5)
        if (!(_nextComboBreak >= 0.5f)) return; // TODO: We can change comboBreaker duration????
        
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

    public override void Exit()
    {
        stateMachine.PlayerInput.OnDodgeInput -= OnDodge;
    }

    private void ComboContinues()
    {
        //Make combo continue
        if(stateMachine.PlayerInput.playerActions.PlayerControls.Fire.triggered) 
        {
            stateMachine.SwitchState(new PlayerAttackState(stateMachine,playerMovement));
        }
        //If there will be no combo input, change current animation to idle. The reason why is that not IdleState, so if current
        // state chaged to idle there is no back to other lines.
        else
        {
            stateMachine.animator.CrossFade(PlayerAnimationsNames.IdleAnim,0.1f);
        }
    }
    
    private void SetAnimationDurationDatas()
    {
        for (int i = 0; i < _attackAnimationsDurations.Count; i++)
        {
            _attackAnimationsDurations[i] = stateMachine.datas.animationClips.GetCombatAnimationData()[i].animation.averageDuration;
        }
    }
    
    private void OnDodge()
    {
        stateMachine.combatData.CurrentCombatIndex = 0;
        stateMachine.SwitchState(new PlayerDodgeState(stateMachine,playerMovement));
    }

}
