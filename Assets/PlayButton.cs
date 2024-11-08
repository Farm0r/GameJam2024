using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButton : MonoBehaviour
{
    [SerializeField] GameObject startScreen;
    public void Play()
    {
        print("Detta h�nder n�r vi klickar p� denna knappen");
        startScreen.SetActive(false);
    }
}
