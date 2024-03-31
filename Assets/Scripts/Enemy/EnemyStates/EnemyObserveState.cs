using System.Collections;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace Enemy.EnemyStates
{
    public class EnemyObserveState : EnemyBaseState
    {
        public EnemyObserveState(EnemyStateMachine enemyEnemyStateMachine, EnemyMovement enemyMovement) : base(enemyEnemyStateMachine, enemyMovement)
        {
        }
        
        public override void Enter()
        {
        }

        public override void Tick(float deltaTime)
        {
            if (IsPlayerInXRange(EnemyStateMachine.EnemyData.PlayerChaseRange))
            {
                EnemyStateMachine.SwitchState(new EnemyChasingState(EnemyStateMachine,EnemyMovement));
            }
            else if (IsPlayerInXRange(EnemyStateMachine.EnemyData.PlayerObserveRange))
            {
                RotateToTarget(EnemyStateMachine.EnemyData.Player.transform.position,deltaTime);
            }
            else
            {
                EnemyStateMachine.SwitchState(new EnemyIdleState(EnemyStateMachine,EnemyMovement));    
            }
        }
        
        public override void Exit()
        {
        }
    }
}
