using UnityEngine;

namespace PlayerData
{
    [CreateAssetMenu(fileName = "PlayerCombatData", menuName = "ScriptableObject/PlayerCombatData")]
    public class PlayerCombatData : ScriptableObject
    {
        public float AttackRange;
        public float AttackKnockbackPower;

        //We can define a class to find what is enemy
        public bool ClosestEnemy;

    }
}
