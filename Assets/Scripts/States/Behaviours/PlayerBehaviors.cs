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

    public void AttackMovement(Transform pos,float travelValue)
    {
        float time = 0f;
        Vector3 forward = pos.forward;
        forward.y = 0;
        forward.Normalize();

        Vector3 targetPos = pos.position + forward;

        while(time < 1f)
        {
            time += Time.deltaTime;
            pos.transform.position = Vector3.MoveTowards(pos.transform.position,targetPos,Time.deltaTime);
            pos.transform.position = Vector3.Lerp(pos.transform.position,targetPos,time);
            //pos.transform.Translate(Vector3.forward * travelValue * Time.deltaTime);
        }
    }
}

