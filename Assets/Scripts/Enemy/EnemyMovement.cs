using UnityEngine;

namespace Enemy
{
    public class EnemyMovement
    {
        public void Movement(EnemyStateMachine stateMachine,float deltaTime, float movement)
        {
            var destination = stateMachine.EnemyData.Agent.destination;
            Vector3 target = new(destination.x,0,destination.z);
        
            stateMachine.transform.position = Vector3.MoveTowards(stateMachine.transform.position,
                target,deltaTime * movement);
        }
        
    
        public void Rotate(EnemyStateMachine stateMachine,float deltaTime, float rotateSpeed)
        {
            var steeringTarget = stateMachine.EnemyData.Agent.steeringTarget;
            var direction = (steeringTarget - stateMachine.transform.position).normalized; 
        
            Vector3 rotation = new(direction.x,0,direction.z);
        
            Quaternion rotationToRotate = Quaternion.LookRotation(rotation);
        
            stateMachine.transform.rotation = 
                Quaternion.Slerp(stateMachine.transform.rotation,rotationToRotate ,rotateSpeed * deltaTime);
        }
        
    }
}
