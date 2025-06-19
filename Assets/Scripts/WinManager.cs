using UnityEngine;
using UnityEngine.SceneManagement;

public class WinManager : MonoBehaviour
{
    public void Retry()
    {
        SceneManager.LoadScene(1); // Recharge le niveau (index 0 ou autre)
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Game Quit!"); // Ne fonctionne que dans build, pas dans l’éditeur
    }
}
