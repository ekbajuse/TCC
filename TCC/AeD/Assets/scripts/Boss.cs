using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : EnemyController 
{
    public static int health;
    private void FixedUpdate()
    {
        if (isMoving && health > 0)
        {
            rb2d.velocity = new Vector2(speed, rb2d.velocity.y);
        }
    }

}
