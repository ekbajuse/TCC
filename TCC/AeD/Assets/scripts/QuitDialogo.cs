using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitDialogo : MonoBehaviour
{
    public GameObject dialogueObj;
    public static bool final = false;
   
    public void Quit()
    {
        dialogueObj.SetActive(false);
        final = true;
    }
}
