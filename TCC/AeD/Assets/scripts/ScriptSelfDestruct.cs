using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptSelfDestruct : QuitDialogo
{
    // Update is called once per frame
    void Update()
    {
        if (final == true )
        {
            Destroy(gameObject);
        }
    }
}
