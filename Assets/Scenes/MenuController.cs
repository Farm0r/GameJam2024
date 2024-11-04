using UnityEngine;
using UnityEngine.SceneManagement; // F�r att hantera scenbyten
using UnityEngine.UI; // F�r UI-komponenter

public class MenuController : MonoBehaviour
{
    // Denna metod anropas n�r Start Game-knappen trycks
    public void StartGame()
    {
        // Ladda "GameScene"
        SceneManager.LoadScene("GameScene");
    }
}
