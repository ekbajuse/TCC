using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bloco : MonoBehaviour
{
    public GameObject on;
    public GameObject off;
    public AudioSource bloco;

    // Start is called before the first frame update
    void Start()
    {
        off.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("bloco"))
        {
           on.SetActive(false);
           off.SetActive(on);
           coletaItem.moeda++;
           bloco.Play();
        }
    }
   
}
