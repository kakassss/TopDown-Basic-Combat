using StateMachines;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerBehaviors
{
    public PlayerMovement playerMovement;
}

public class PlayerMovement
{ 
    public void Movement(float deltaTime,PlayerStateMachine stateMachine, float movement)
    {
        //Vector3 zRelativeVectorX = movementVector.x * transform.right;
        Vector3 zRelativeVectorZ = new(stateMachine.PlayerInput.movementVector.x,0,stateMachine.PlayerInput.movementVector.y);
        stateMachine.transform.position += zRelativeVectorZ * deltaTime * movement;
    }

    public void Rotate(float deltaTime,PlayerStateMachine stateMachine, float movement)
    {
        if(stateMachine.PlayerInput.movementVector == Vector3.zero) return;
        Vector3 rotation = new(stateMachine.PlayerInput.movementVector.x,0,stateMachine.PlayerInput.movementVector.y);


        Quaternion rotationToRotate = Quaternion.LookRotation(rotation);
        stateMachine.transform.rotation = Quaternion.Slerp(stateMachine.transform.rotation,rotationToRotate ,movement * deltaTime);
    }

    public void Dodge(Transform transform, int travellingValue)
    {
        transform.transform.Translate(Vector3.forward * travellingValue * Time.deltaTime);
    }


    #region AttackMovement
    
    private const float MinAttackMovementDistance = 1.35f;
    
    private Vector3 _forward;
    private Vector3 _targetPos;
    
    public void SetAttackMovementWithOutTargetData(Transform pos,float travelValue)
    {
        _forward = pos.forward;
        _forward.y = 0;
        _forward.Normalize();

        _targetPos = pos.position + (_forward * travelValue);
    }

    private Vector3 _targetEnemyPos;
    private float _distance;
    public void SetAttackMovementToEnemyData(Transform pos, Transform enemyPos, float travelValue)
    {
        var targetPos = enemyPos.position;
        var playerPos = pos.position;
        
        var distanceVector = (targetPos - playerPos).normalized;
        _targetEnemyPos = (distanceVector * travelValue + playerPos);
        
        _distance = Vector3.Distance(playerPos, targetPos);
    }
    
    
    public void SetAttackMovementToEnemy(Transform pos,Vector3 enemyPos)
    {
        pos.transform.LookAt(enemyPos);
        
        if(_distance <= MinAttackMovementDistance) return;
        
        pos.transform.position = Vector3.MoveTowards(pos.transform.position, _targetEnemyPos , Time.deltaTime);
    }
    
    public void AttackMovementWithOutTarget(Transform pos) // TODO: maybe use AnimationCurve curve instead of time.deltaTime
    {
        //TODO: you can try vector3.smoothdamp or lerp functions insted of moveTowards
        pos.transform.position = Vector3.MoveTowards(pos.transform.position, _targetPos, Time.deltaTime);
    }
    
    #endregion
    
}

