using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    // Denna metod anropas n�r n�got g�r in i m�llinjens trigger
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Kontrollera om det �r spelaren som g�r in i triggern
        if (other.CompareTag("Player"))
        {
            Debug.Log("Game Over! Player crossed the finish line.");
            // H�r kan du avsluta spelet eller ladda en ny scen
            // Exempel p� att avsluta spelet:
            Application.Quit();

            // OBS: Application.Quit() fungerar endast n�r spelet k�rs som en byggd version, inte i Unity Editor.
            // Om du vill testa i Unity Editor, anv�nd Debug.Log f�r att se att det fungerar.
        }
    }
}