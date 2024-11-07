using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlappyBird : MonoBehaviour
{
    public PlayerMovement playerMovement;




    private void OnTriggerExit2D(Collider2D collision)
    {
        playerMovement.maxJumps = 2;
    }
}
