using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger ENTERED with: " + other.name);
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("💀 Player touched enemy! Game Over.");
            Die();
        }
    }

    void Die()
    {
        // Recharge la scène actuelle
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
