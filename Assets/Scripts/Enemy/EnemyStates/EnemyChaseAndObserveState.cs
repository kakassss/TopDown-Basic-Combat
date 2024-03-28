using System.Collections;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace Enemy.EnemyStates
{
    public class EnemyChaseAndObserveState : EnemyBaseState
    {
        private const float DampTime = 0.1f;
        private CancellationToken _returnStartPositionToken;

        private float _waitDuration;
        public EnemyChaseAndObserveState(EnemyStateMachine enemyStateMachine, EnemyMovement enemyMovement) : base(enemyStateMachine, enemyMovement)
        {
        }
        
        public override void Enter()
        {
            _waitDuration = 0;
            StateMachine.Animator.SetFloat(EnemyAnimationsNames.IdleToRunBlend, 0.1f);
        }

        public override void Tick(float deltaTime)
        {

            if (GetDistanceToPlayer(StateMachine.transform) <= 6f && GetDistanceToPlayer(StateMachine.transform) >= StateMachine.PlayerChaseRange)
            {
                Animation(0f);
                _waitDuration += deltaTime;
                WaitAndReturnStartPosition(_waitDuration);
            }
            else if (IsPlayerXRange(StateMachine.PlayerChaseRange))
            {
                StateMachine.SwitchState(new EnemyChasingState(StateMachine,EnemyMovement));
            }
            else if (IsPlayerXRange(StateMachine.PlayerObserveRange))
            {
                MovementToPlayer(deltaTime);
                Animation(0.5f);
            }
            else
            {
                StateMachine.SwitchState(new EnemyIdleState(StateMachine,EnemyMovement));    
            }
            
            void Animation(float value)
            {
                StateMachine.Animator.SetFloat(EnemyAnimationsNames.IdleToRunBlend, value,DampTime,deltaTime);
            }
        }

        private  void WaitAndReturnStartPosition(float deltaTime)
        {
            if (deltaTime >= 2f)
            {
                StateMachine.SwitchState(new EnemyReturnStartPositionState(StateMachine,EnemyMovement));
            }
        }
        
        public override void Exit()
        {
            
        }
    }
}
