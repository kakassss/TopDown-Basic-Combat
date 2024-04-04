using System;
using PlayerData;
using States;
using UnityEngine;

namespace StateMachines
{
    public class PlayerStateMachine : StateMachine
    {
        [field: SerializeField] public PlayerInput PlayerInput {get; private set;}
        
        public PlayerCombatData combatData;
        public PlayerStateDatas datas;
        public Animator animator;
        
        public int CurrentCombatIndex {get; set;}

        [HideInInspector] public GameObject Enemy;

        private PlayerMovement _playerMovement;
        private void Start()
        {
            _playerMovement = new();
            Enemy = GameObject.FindGameObjectWithTag("Enemy");

            SwitchState(new PlayerIdleState(this,_playerMovement));
            SwichHelperState(new PlayerEmptyState(this,_playerMovement));
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position,combatData.AttackRange);
        }
    }
}
