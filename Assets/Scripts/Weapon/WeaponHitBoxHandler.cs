using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHitBoxHandler : MonoBehaviour
{
    [SerializeField] private GameObject collider;
    
    public void OpenHitbox()
    {
        collider.SetActive(true);
    }

    public void CloseHitbox()
    {
        collider.SetActive(false);
    }
}
