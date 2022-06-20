using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pararmusica : MonoBehaviour
{
    public AudioSource musicLevel;
    void Update()
    {
        if (PlayerLevel3.encostou > 0)
        {
            musicLevel.Stop();
        }

    }
}