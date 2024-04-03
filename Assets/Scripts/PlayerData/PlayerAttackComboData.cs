using System;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerData
{
    [CreateAssetMenu(fileName = "PlayerAttackComboDatas", menuName = "ScriptableObject/PlayerAttackComboDatas")]
    public class PlayerAttackComboData : ScriptableObject
    {
        [SerializeField] private List<string> attackComboNamesList;
        public List<string> AttackComboNamesList => attackComboNamesList;
        
    }

    
}