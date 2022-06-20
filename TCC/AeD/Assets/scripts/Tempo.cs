using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tempo : MonoBehaviour
{
    public Rigidbody2D rb;

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name.Equals("Player"))
        {
            rb.bodyType = RigidbodyType2D.Dynamic;
            rb.mass = 50f;
            rb.gravityScale = 0.5f;
        }
    }
}
