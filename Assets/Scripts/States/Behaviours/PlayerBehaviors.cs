using System.Collections;
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
    
    private Vector3 forward;
    private Vector3 targetPos;
    
    public void SetAttackMovementData(Transform pos,float travelValue,AnimationCurve curve)
    {
        forward = pos.forward;
        forward.y = 0;
        forward.Normalize();

        targetPos = pos.position + (forward * travelValue);
        //pos.transform.position = Vector3.MoveTowards(pos.transform.position, targetPos, Time.deltaTime);
    }

    public void AttackMovement(Transform pos)
    {
        pos.transform.position = Vector3.MoveTowards(pos.transform.position, targetPos, Time.deltaTime);
    }
    
    #endregion
    
}

