using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteAfterPlay : MonoBehaviour
{
    public AudioSource sounds;
    // Update is called once per frame
    void Update()
    {
        if (sounds.isPlaying == false)
        {
            Destroy(gameObject);
        }
    }
}
