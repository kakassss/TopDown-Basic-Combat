using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDamage : MonoBehaviour
{
    private List<Collider> alreadyDamaged = new List<Collider>();

    private void OnEnable()
    {
        alreadyDamaged.Clear();
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if(alreadyDamaged.Contains(other)) return;
        
        alreadyDamaged.Add(other);
        
        if (other.TryGetComponent<Health>(out Health health))
        {
            health.GetDamage(5);
        }
    }
}
