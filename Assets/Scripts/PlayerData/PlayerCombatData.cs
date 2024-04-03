using System;
using UnityEngine.Serialization;

[Serializable]
public class PlayerCombatData
{
    public int CurrentCombatIndex {get; set;}
    
    
    public float AttackRange;
    public float AttackKnockbackPower;

    //We can define a class to find what is enemy
    public bool ClosestEnemy;

}
