using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;


[CreateAssetMenu(fileName = "PlayerAttackComboDatas", menuName = "ScriptableObject/PlayerAttackComboDatas")]
public class PlayerAttackComboData : ScriptableObject
{
    [SerializeField] private List<string> attackComboNamesList;
    public List<string> AttackComboNamesList => attackComboNamesList;
    

    public CombatActionData CombatActionData;
}

[Serializable]
public class CombatActionData
{
    public bool IsEnemyInRange;
    public float EnemyDistanceToAttackMagnitude;
    public float KnockbackPower;

    //We can define a class to find what is enemy
    public bool ClosestEnemy;


    

}