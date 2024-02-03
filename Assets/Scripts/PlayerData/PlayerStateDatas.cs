using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStateDatas", menuName = "ScriptableObject/PlayerStateDatas", order = 0)]
public class PlayerStateDatas : ScriptableObject 
{
    public PlayerStats stats;
    public PlayerAnimationClips animationClips;

}

[Serializable]
public class PlayerStats
{
    [Header("Rotate")]
    public float rotateSpeed;

    [Header("Movement")]
    public float movementSpeed;

    [Header("Jump")]
    public float jumpForce;

}

[Serializable]
public class PlayerAnimationClips
{
    [Header("Movement Animation Clips")]
    public AnimationClip DodgeAnimation;

    [Header("Combat Anim Clips")]
    [SerializeField] private List<AnimationClip> LeftClickCombatList;

    public string GetCurrentCombatAnimationName(int index)
    {
        return LeftClickCombatList[index].name;
    }

    
}
