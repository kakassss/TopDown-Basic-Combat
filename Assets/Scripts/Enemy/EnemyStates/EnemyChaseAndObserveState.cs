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
        public EnemyChaseAndObserveState(EnemyStateMachine enemyEnemyStateMachine, EnemyMovement enemyMovement) : base(enemyEnemyStateMachine, enemyMovement)
        {
        }
        
        public override void Enter()
        {
            Debug.Log("reel onur 2 " + EnemyStateMachine.EnemyData.EnemyInitPosition);
            _waitDuration = 0;
            EnemyStateMachine.EnemyData.Animator.SetFloat(EnemyAnimationsNames.IdleToRunBlend, 0.1f);
        }

        public override void Tick(float deltaTime)
        {
            //TODO: can we get rid of these if blocks?
            if (GetDistanceValueToPlayer(EnemyStateMachine.transform) <= 6f 
                && GetDistanceValueToPlayer(EnemyStateMachine.transform) >= EnemyStateMachine.EnemyData.PlayerChaseRange)
            {
                Animation(0f);
                _waitDuration += deltaTime;
                WaitAndReturnStartPosition(_waitDuration);
            }
            else if (IsPlayerInXRange(EnemyStateMachine.EnemyData.PlayerChaseRange))
            {
                EnemyStateMachine.SwitchState(new EnemyChasingState(EnemyStateMachine,EnemyMovement));
            }
            else if (IsPlayerInXRange(EnemyStateMachine.EnemyData.PlayerObserveRange))
            {
                MovementToPlayer(deltaTime,1.25f);
                Animation(0.5f);
            }
            else
            {
                EnemyStateMachine.SwitchState(new EnemyIdleState(EnemyStateMachine,EnemyMovement));    
            }
            
            void Animation(float value)
            {
                EnemyStateMachine.EnemyData.Animator.SetFloat(EnemyAnimationsNames.IdleToRunBlend, value,DampTime,deltaTime);
            }
        }

        private void WaitAndReturnStartPosition(float deltaTime)
        {
            if (deltaTime >= 2f)
            {
                EnemyStateMachine.SwitchState(new EnemyReturnStartPositionState(EnemyStateMachine,EnemyMovement));
            }
        }
        
        public override void Exit()
        {
            
        }
    }
}
