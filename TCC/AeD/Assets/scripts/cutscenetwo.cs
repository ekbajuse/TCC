using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cutscenetwo : MonoBehaviour
{
    public GameObject cameraCut;
    public GameObject cutscenetwoCamera;    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            cameraCut.SetActive(true);
            cutscenetwoCamera.SetActive(false);

        }
    }
}
