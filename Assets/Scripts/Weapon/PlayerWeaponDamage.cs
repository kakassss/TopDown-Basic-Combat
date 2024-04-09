using System.Collections.Generic;
using Health;
using UnityEngine;

public class PlayerWeaponDamage : MonoBehaviour
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
        
        if (other.TryGetComponent<EnemyHealthAbstractBase>(out EnemyHealthAbstractBase health))
        {
            health.GetDamage(5);
            EventBus<EnemyTakenDamageEvent>.Fire(new EnemyTakenDamageEvent());
        }
    }
}
