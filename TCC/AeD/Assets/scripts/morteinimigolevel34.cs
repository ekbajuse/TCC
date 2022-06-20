using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class morteinimigolevel34 : MonoBehaviour
{
    public Animator anim;
 
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();    
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerLevel3.morte == 4)
        {
            anim.SetBool("emorreu", true);
        }
    }
}
