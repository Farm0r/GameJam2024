using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    [SerializeField] Slider healthBar;
    [SerializeField] float health = 10;
    public Rigidbody2D rb; // Ref till vår rigidbody
                           // [SerializeField] private AudioSource deathSoundEffect;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) // Om vi kolliderar med trap, starta die funktionen
        {
            TakeDamage(0.5f);
        }
        if (collision.gameObject.CompareTag("Spike")) // Om vi kolliderar med trap, starta die funktionen
        {
            TakeDamage(1);
        }
    }    
    
    void TakeDamage(float amount)
    {

        health -= amount;
        healthBar.value = health;
        if (health <= 0)
        {
            Die();
        }
    }
    private void Die() // Spela death animationen och sätt rigidbody på static så vi inte kan röra oss
    {
        //gameoverscreen.setActive(true)
        rb.bodyType = RigidbodyType2D.Static;
        RestartLevel();
    }
    private void RestartLevel()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}
