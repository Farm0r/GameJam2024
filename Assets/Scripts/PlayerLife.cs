using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    
    public Rigidbody2D rb; // Ref till v�r rigidbody
                           // [SerializeField] private AudioSource deathSoundEffect;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) // Om vi kolliderar med trap, starta die funktionen
        {
            Die();
        }
        if (collision.gameObject.CompareTag("Spike")) // Om vi kolliderar med trap, starta die funktionen
        {
            Die();
        }
    }                                                                                                                                                   
    private void Die() // Spela death animationen och s�tt rigidbody p� static s� vi inte kan r�ra oss
    {
        
        rb.bodyType = RigidbodyType2D.Static;
        RestartLevel();
    }
    private void RestartLevel()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}
