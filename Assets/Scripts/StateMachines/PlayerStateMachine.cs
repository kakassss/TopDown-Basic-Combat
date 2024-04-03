using PlayerData;
using States;
using UnityEngine;

namespace StateMachines
{
    public class PlayerStateMachine : StateMachine
    {
        [field: SerializeField] public PlayerInput PlayerInput {get; private set;}
        [SerializeField] public PlayerStateDatas datas;
        public PlayerCombatData combatData;
        [SerializeField] public Animator animator;

        private PlayerMovement _playerMovement;

        [HideInInspector] public GameObject Enemy;
        private void Start()
        {
            _playerMovement = new();
            Enemy = GameObject.FindGameObjectWithTag("Enemy");
            combatData = new();

            SwitchState(new PlayerIdleState(this,_playerMovement));
            SwichHelperState(new PlayerEmptyState(this,_playerMovement));
        }

    }
}
