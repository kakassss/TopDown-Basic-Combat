using UnityEngine;

public abstract class StateMachine : MonoBehaviour
{
    private State currentState;
    private State helperState;
    
    public void SwitchState(State newState)
    {
        currentState?.Exit();
        currentState = newState;
        currentState?.Enter();
    }

    public void SwichHelperState(State newHelperState)
    {
        helperState?.Exit();
        helperState = newHelperState;
        helperState?.Enter();
    }
    
    private void Update()
    {
        currentState?.Tick(Time.deltaTime);
        helperState?.Tick(Time.deltaTime);

        DebugCurrentState();
    }

    private void DebugCurrentState()
    {
        Debug.Log("Current state is " + currentState);
    }
}
