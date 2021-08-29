using UnityEngine;
using UnityEngine.SceneManagement;

public class BossDead : MonoBehaviour
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
        SceneManager.LoadScene(2);
    }
}

