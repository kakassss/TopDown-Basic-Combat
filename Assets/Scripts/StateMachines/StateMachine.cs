using UnityEngine;

namespace StateMachines
{
    public abstract class StateMachine : MonoBehaviour
    {
        private State _currentState;
        private State _helperState;
    
        public void SwitchState(State newState)
        {
            _currentState?.Exit();
            _currentState = newState;
            _currentState?.Enter();
        }

        public void SwichHelperState(State newHelperState)
        {
            _helperState?.Exit();
            _helperState = newHelperState;
            _helperState?.Enter();
        }
    
        private void Update()
        {
            _currentState?.Tick(Time.deltaTime);
            _helperState?.Tick(Time.deltaTime);

            DebugCurrentState();
        }

        private void DebugCurrentState()
        {
            Debug.Log("Current state is " + _currentState);
        }
    }
}
