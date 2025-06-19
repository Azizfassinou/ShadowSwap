using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;
    private int currentHealth;

    public TextMeshProUGUI healthText; 
    public GameOverManager gameOverManager;

    private bool isDead = false; // Pour bloquer après mort

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthUI();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (isDead) return; // Bloque les dégâts si déjà mort

        if (other.CompareTag("Enemy"))
        {
            currentHealth--;
            UpdateHealthUI();

            if (currentHealth <= 0)
            {
                Die();
            }
        }
    }

    void Die()
    {
        isDead = true; // ✅ Empêche plusieurs appels
        Debug.Log("💀 Game Over");
        gameOverManager.GameOver();
    }

    void UpdateHealthUI()
    {
        if (healthText != null)
        {
            healthText.text = "Life : x" + Mathf.Max(currentHealth, 0); 
        }

        void OnTriggerEnter2D(Collider2D other)
        {
    
            if (other.CompareTag("Finish"))
            {
                Debug.Log(" Level Completed!");
                SceneManager.LoadScene("WinScene"); 
            }
        }

    }
}
