using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    // Denna metod anropas när något går in i mållinjens trigger
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Kontrollera om det är spelaren som går in i triggern
        if (other.CompareTag("Player"))
        {
            Debug.Log("Game Over! Player crossed the finish line.");
            // Här kan du avsluta spelet eller ladda en ny scen
            // Exempel på att avsluta spelet:
            Application.Quit();

            // OBS: Application.Quit() fungerar endast när spelet körs som en byggd version, inte i Unity Editor.
            // Om du vill testa i Unity Editor, använd Debug.Log för att se att det fungerar.
        }
    }
}