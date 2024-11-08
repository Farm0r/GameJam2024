using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButton : MonoBehaviour
{
    [SerializeField] GameObject startScreen;
    public void Play()
    {
        print("Detta händer när vi klickar på denna knappen");
        startScreen.SetActive(false);
    }
}
