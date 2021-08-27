using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class PlayerTakeDamage : MonoBehaviour
{
    public float health;

    public Slider healthBar;
    public TMP_Text healthCounter;

    private void Update()
    {
        healthBar.value = health;
        healthCounter.text = health.ToString();
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
