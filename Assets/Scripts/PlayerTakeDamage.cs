using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class PlayerTakeDamage : MonoBehaviour
{
    public float health = 100f;
    public Slider healthBar;

    public TMP_Text playerHealthCounter;

    private void Update()
    {
        playerHealthCounter.text = health.ToString();
        healthBar.value = health;
    }

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
