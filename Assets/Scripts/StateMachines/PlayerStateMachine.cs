using PlayerData;
using StateMachines;
using PlayerStates;
using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    [field: SerializeField] public PlayerInput PlayerInput {get; private set;}
    [SerializeField] public PlayerStateDatas datas;
    [SerializeField] public PlayerAttackComboData comboDatas;
    public PlayerCombatData combatData;
    [SerializeField] public Animator animator;

    private PlayerMovement _playerMovement;
    private void Start()
    {
        _playerMovement = new();
        combatData = new();

        SwitchState(new PlayerIdleState(this,_playerMovement));
        SwichHelperState(new PlayerEmptyState(this,_playerMovement));
    }

}
