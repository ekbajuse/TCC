using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inimigoTipo2 : MonoBehaviour
{
    private Vector3 isUp;
    private Vector3 isDown;
    
    public Rigidbody2D rb;

    private bool moveDown = true;

    public float velocidade = 6f;
    public Transform pontoA;
    public Transform pontoB;

    // Start is called before the first frame update
    void Start()
    {
        isUp = transform.localScale;
        isDown = transform.localScale;
        rb = GetComponent<Rigidbody2D>();
        isDown.y = isDown.y * -1;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > pontoA.position.y)
        {
            moveDown = true;
            transform.localScale = isDown;
        }
        if (transform.position.y < pontoB.position.y)
        {
            moveDown = false;
            transform.localScale = isUp;
        }

        if (moveDown)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - velocidade * Time.deltaTime);
        }
        else
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + velocidade * Time.deltaTime);
        }
    }
}
