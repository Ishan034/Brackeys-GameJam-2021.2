using UnityEngine;

public class TakeDamage : MonoBehaviour
{
    public float health;
 
    public void DamageHealth(float amount)
    {
        health -= amount;

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
