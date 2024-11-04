using UnityEngine;
using UnityEngine.SceneManagement; // För att hantera scenbyten
using UnityEngine.UI; // För UI-komponenter

public class MenuController : MonoBehaviour
{
    // Denna metod anropas när Start Game-knappen trycks
    public void StartGame()
    {
        // Ladda "GameScene"
        SceneManager.LoadScene("GameScene");
    }
}
