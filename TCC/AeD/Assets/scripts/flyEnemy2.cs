using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flyEnemy2 : EnemyController
{
    public static int health = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        if (isMoving && health != 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, Mathf.Abs(speed) * Time.deltaTime);
        }

    }

}
