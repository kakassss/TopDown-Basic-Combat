using System.Collections;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace Enemy.EnemyStates
{
    public class EnemyObserveState : EnemyBaseState
    {
        private const float DampTime = 0.1f;
        private CancellationToken _returnStartPositionToken;

        private float _waitDuration;
        public EnemyObserveState(EnemyStateMachine enemyEnemyStateMachine, EnemyMovement enemyMovement) : base(enemyEnemyStateMachine, enemyMovement)
        {
        }
        
        public override void Enter()
        {
            Debug.Log("reel onur 2 " + EnemyStateMachine.EnemyData.EnemyInitPosition);
            _waitDuration = 0;
            Animation_IdleRunBlend(0.1f,0);
        }

        public override void Tick(float deltaTime)
        {
            //TODO: can we get rid of these if blocks?
            var distancePlayer = GetDistanceValueToPlayer(EnemyStateMachine.transform);
            
            if (distancePlayer <= 6f && distancePlayer >= EnemyStateMachine.EnemyData.PlayerChaseRange)
            {
                Animation_IdleRunBlend(0f,deltaTime);
                _waitDuration += deltaTime;
                WaitAndReturnStartPosition(_waitDuration);
            }
            else if (IsPlayerInXRange(EnemyStateMachine.EnemyData.PlayerChaseRange))
            {
                EnemyStateMachine.SwitchState(new EnemyChasingState(EnemyStateMachine,EnemyMovement));
            }
            else if (IsPlayerInXRange(EnemyStateMachine.EnemyData.PlayerObserveRange))
            {
                MovementAndRotateToPlayer(deltaTime,1.25f);
                Animation_IdleRunBlend(0.5f,deltaTime);
            }
            else
            {
                EnemyStateMachine.SwitchState(new EnemyIdleState(EnemyStateMachine,EnemyMovement));    
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
