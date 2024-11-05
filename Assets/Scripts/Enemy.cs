using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 100;
    public float chaseRadius = 10f; // radie inom vilken fienden ska jaga spelaren
    public float obstacleCheckDistance = 1f; // avståndet som fienden ska kolla efter hinder framför sig
    public LayerMask obstacleLayerMask; // vilken lager fienden ska kolla efter hinder på
    public Animator animator;
    private Transform target; // referens till spelaren
    private bool isChasing = false; // flagga för att indikera om fienden jagar eller inte
    public float moveSpeed = 5f;

    public void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform; // söker efter spelaren i scenen baserat på taggen "Player"
    }

    private void Update()
    {
        if (Vector3.Distance(target.position, transform.position) <= chaseRadius) // kollar om spelaren är inom radie
        {
            isChasing = true;


        }
        else
        {
            isChasing = false;
        }
        if (isChasing)
        {
            
            Vector2 direction = (target.position - transform.position).normalized;
            Vector2 boxSize = new Vector2(1f, 1f); // storleken på boxen som fienden ska kolla i
            RaycastHit2D hit = Physics2D.BoxCast(transform.position, boxSize, 0f, direction, obstacleCheckDistance, obstacleLayerMask);
            if (hit.collider == null)
            {
                
                Vector3 targetPosition = new Vector3(target.position.x, transform.position.y, transform.position.z);
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
            }
        }
    }

    public void TakeDamage(int damage)
    {
        Debug.Log("health before");
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
        Debug.Log("health ");
    }
    void Die()
    {
        Destroy(gameObject);
    }

}
