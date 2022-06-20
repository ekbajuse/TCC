using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Botao : MonoBehaviour
{
    public string nomeDaCena;

    public void TrocaDeCena()
    {
        SceneManager.LoadScene(nomeDaCena);
    }

    public void Sair() 
    {
        Application.Quit();
    }
}
