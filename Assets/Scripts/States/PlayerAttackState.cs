using System;
using System.Collections.Generic;
using PlayerData;
using StateMachines;
using UnityEngine;

namespace States
{
    public class PlayerAttackState : PlayerBaseState
    {
        private const float ComboBreakDuration = 0.45f;
        private const float AnimTransitionDuration = 0.5f;
            
        private List<float> _attackAnimationsDurations;
    
        private CombatAnimationData _currentAnimation;
    
        private float _currentAnimationNormalizeDuration;
        private float _attack1AnimationTime;
        private float _attack2AnimationTime;

        private float _attackTimeLimit;
        private float _nextComboBreakCounter;
    
        public PlayerAttackState(PlayerStateMachine stateMachine,PlayerMovement playerMovement) : base(stateMachine,playerMovement)
        {
        }

        public override void Enter()
        {
            StateMachine.PlayerInput.OnDodgeInput += OnDodge;
        
            _attackAnimationsDurations = new List<float>(new float[StateMachine.datas.animationClips.GetCombatAnimationData().Count]);
            SetAnimationDurationDatas();
        
            _attackTimeLimit = 0;
            _nextComboBreakCounter = 0;
        
            StateMachine.animator.CrossFadeInFixedTime(
                StateMachine.datas.animationClips.GetCurrentCombatAnimationName(StateMachine.CurrentCombatIndex),
                AnimTransitionDuration);
        
            //Get the current Animation combatData
            _currentAnimation =
                StateMachine.datas.animationClips.GetCombatAnimationData()[StateMachine.CurrentCombatIndex];
            //Get the current combat animation average duration diveded by our value. With this value we find kind of normalize animation duration
            _currentAnimationNormalizeDuration =
                (_currentAnimation.animation.averageDuration / _currentAnimation.animationSpeed) - _currentAnimation.animationDurationOffset;
        
            //Increase current combo count
            StateMachine.CurrentCombatIndex++;
        
            //Check currentCombo is max or not
            if(StateMachine.CurrentCombatIndex >= StateMachine.datas.animationClips.LeftClickCombatList.Count)
            {
                StateMachine.CurrentCombatIndex = 0;
            }

            SetAttackMovementData();
        }
    
        public override void Tick(float deltaTime)
        {
            _attackTimeLimit += Time.deltaTime;

            AttackMovement();

            if (!(_attackTimeLimit > _currentAnimationNormalizeDuration)) return;
        
            ComboContinues();
            
            //After current combo animation played, if player does not want to continue combo walk instead
            if (StateMachine.PlayerInput.playerActions.PlayerControls.Movement.triggered)
            {
                StateMachine.SwitchState(new PlayerMovementState(StateMachine,PlayerMovement));
                StateMachine.CurrentCombatIndex = 0;
            }
            
            _nextComboBreakCounter += Time.deltaTime;
            
            //Player can continue his combo after a while later(currently 0.5)
            if (!(_nextComboBreakCounter >= ComboBreakDuration)) return;
        
            StateMachine.CurrentCombatIndex = 0;
            //After current combo finished, if player holds wasd or gamepad stick inputs, can walk
            if (StateMachine.PlayerInput.playerActions.PlayerControls.Movement.IsInProgress())
            {
                StateMachine.SwitchState(new PlayerMovementState(StateMachine,PlayerMovement));
            }
            else
            {
                StateMachine.SwitchState(new PlayerIdleState(StateMachine,PlayerMovement));
            }
        }

        public override void Exit()
        {
            StateMachine.PlayerInput.OnDodgeInput -= OnDodge;
        }

        private void ComboContinues()
        {
            //Make combo continue
            if(StateMachine.PlayerInput.playerActions.PlayerControls.Fire.triggered) 
            {
                StateMachine.SwitchState(new PlayerAttackState(StateMachine,PlayerMovement));
            }
            //If there will be no combo input, change current animation to idle. The reason why is that not IdleState, so if current
            // state chaged to idle there is no back to other lines.
            else
            {
                StateMachine.animator.CrossFade(PlayerAnimationsNames.IdleAnim,0.1f);
            }
        }

        private void SetAttackMovementData()
        {
            SetCurrentAttackMovement(
                (() => PlayerMovement.SetAttackMovementToEnemyData(StateMachine.transform,StateMachine.Enemy.transform,0.5f)),
                (() => PlayerMovement.SetAttackMovementWithOutTargetData(StateMachine.transform,0.3f)));
        }

        private void AttackMovement()
        {
            SetCurrentAttackMovement(
                (() => PlayerMovement.SetAttackMovementToEnemy(StateMachine.transform,StateMachine.Enemy.transform.position)),
                (() => PlayerMovement.AttackMovementWithOutTarget(StateMachine.transform)));
        }
        
        private void SetCurrentAttackMovement(Action OnTrue = null, Action OnFalse = null)
        {
            if (IsEnemyInAttackRange(StateMachine.combatData.AttackRange))
            {
                OnTrue?.Invoke();
            }
            else
            {
                OnFalse?.Invoke();
            }
        }
        
        private void SetAnimationDurationDatas()
        {
            for (int i = 0; i < _attackAnimationsDurations.Count; i++)
            {
                _attackAnimationsDurations[i] = StateMachine.datas.animationClips.GetCombatAnimationData()[i].animation.averageDuration;
            }
        }
    
        private void OnDodge()
        {
            StateMachine.CurrentCombatIndex = 0;
            StateMachine.SwitchState(new PlayerDodgeState(StateMachine,PlayerMovement));
        }
        
    }
}
