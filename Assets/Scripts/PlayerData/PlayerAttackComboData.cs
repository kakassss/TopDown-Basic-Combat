using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "PlayerAttackComboDatas", menuName = "ScriptableObject/PlayerAttackComboDatas")]
public class PlayerAttackComboData : ScriptableObject
{
    //[SerializeField] private List<string> attackCombos;

    [SerializeField] private List<string> attackComboNamesList;

    public List<string> AttackComboNamesList => attackComboNamesList;


    // public List<string> GetCombatAnimationNames()
    // {
    //     foreach (var item in attackCombos)
    //     {
    //         attackComboNamesList.Add(item.name);
    //     }

    //     return attackComboNamesList;
    // } 
}
