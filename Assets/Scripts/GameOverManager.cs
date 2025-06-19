using UnityEngine; 
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverPanel;

    public void GameOver()
    {
        Time.timeScale = 0f; // Met en pause le jeu
        gameOverPanel.SetActive(true);
    }

    public void Retry()
    {
        Time.timeScale = 1f; // Reprend le temps
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
