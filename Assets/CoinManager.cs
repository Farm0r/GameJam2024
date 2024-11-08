using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    public int coinsCollected = 0;
    public Text text;
    public GameObject coinSound;

    private void Update()
    {
        text.text = "Coins collected: " + coinsCollected;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Point")
        {
            coinsCollected += 1;
            Instantiate(coinSound);
            Destroy(collision.gameObject);

        }
    }
}
