using StateMachines;
using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    [field: SerializeField] public PlayerInput PlayerInput {get; private set;}
    [SerializeField] public PlayerStateDatas datas;
    [SerializeField] public PlayerAttackComboData comboDatas;
    public PlayerCombatData combatData;
    [SerializeField] public Animator animator;
     public AnimationCurve her;

    protected PlayerMovement playerMovement;
    private void Start()
    {
        playerMovement = new();
        combatData = new();

        SwitchState(new PlayerIdleState(this,playerMovement));
        SwichHelperState(new PlayerEmptyState(this,playerMovement));
    }

}
