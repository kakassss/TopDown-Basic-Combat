using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int health;


    public void GetDamage(int damage)
    {
        if (health <= 0)
        {
            health = 0;
            return;
        }
        
        health -= damage;
        
        Debug.Log("current object " + gameObject.name + " health " + health);
    }
}
