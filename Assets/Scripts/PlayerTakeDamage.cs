using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerTakeDamage : MonoBehaviour
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
