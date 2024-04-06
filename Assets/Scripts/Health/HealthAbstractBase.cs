using UnityEngine;

namespace Health
{
    public class HealthAbstractBase : MonoBehaviour
    {
        [SerializeField] protected int health;


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
}
