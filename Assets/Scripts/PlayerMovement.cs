using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Hur snabbt vår karaktär får röra sig
    public float jumpForce = 5f; // Vilken kraft hoppet använder
    public Transform groundCheck; // Kolla om spelaren har rört vid marken
    public float groundCheckRadius = 0.2f; // Inom vilken radie kan vi röra marken
    public LayerMask groundLayer; // Vilket lager har marken
    private bool isFacingRight = true; // Kolla vilket håll karaktären tittar åt
    private bool isGrounded = false; // Om vi är på marken eller inte
    private Rigidbody2D rb; // Referens till vår Rigidbody2D

    private int jumpCount = 0; // Räkna hopp
    public int maxJumps = 2; // Antal hopp spelaren kan göra (dubbelhopp = 2)

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Hämta vår Rigidbody2D
    }

    private void Update()
    {
        // Kolla om spelaren är på marken
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        // Återställ hoppantalet om spelaren är på marken
        if (isGrounded)
        {
            jumpCount = 0;
        }

        // Få input för horisontell rörelse
        float moveDirection = Input.GetAxis("Horizontal");
        Move(moveDirection); // Flytta spelaren

        // Flippa spelaren beroende på rörelseriktning
        if (moveDirection > 0 && !isFacingRight)
        {
            Flip();
        }
        else if (moveDirection < 0 && isFacingRight)
        {
            Flip();
        }

        // Kolla om spelaren trycker på hoppknappen och kan hoppa
        if (Input.GetButtonDown("Jump") && (isGrounded || jumpCount < maxJumps))
        {
            Jump();
            jumpCount++;
        }
    }

    private void Move(float direction)
    {
        // Beräkna hur vi rör oss i relation till spelarens velocity
        Vector2 movement = new Vector2(direction * moveSpeed, rb.velocity.y);
        rb.velocity = movement;
    }

    private void Jump()
    {
        // Nollställ spelarens vertikala hastighet innan hopp för mer konsekventa hopp
        rb.velocity = new Vector2(rb.velocity.x, 0f);
        rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse); // Lägg till vertikal kraft för att hoppa
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight; // Flippa player spriten horisontellt
        transform.Rotate(0f, 180f, 0f);
        Transform firepoint = transform.Find("FirePoint");
        if (firepoint != null)
        {
            firepoint.localPosition = isFacingRight ? new Vector3(1, firepoint.localPosition.y, firepoint.localPosition.z) : new Vector3(2, firepoint.localPosition.y, firepoint.localPosition.z);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "NextLevel")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        if (collision.tag == "PreviousLevel")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }
}
