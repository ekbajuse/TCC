using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class coletaItem : MonoBehaviour
{
    public Text moedaTxt;
    public static int moeda;
    public AudioSource coletaMoeda; 

    private void Start()
    {
        moeda = 0;
    }

    public void Update()
    {
        moedaTxt.text = moeda.ToString();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("moedas"))
        {
            moeda = moeda + 1;
            other.gameObject.SetActive(false);
            coletaMoeda.Play(); 
        }
    }
}
