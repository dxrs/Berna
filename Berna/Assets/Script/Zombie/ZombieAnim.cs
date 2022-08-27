using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAnim : MonoBehaviour
{
    public Animator anim;
    public static bool isAttack = false;

    void Update()
    {
        if(!isAttack)
        {
            anim.SetFloat("Speed",ZombieAi.velo, 0.1f, Time.deltaTime);
            anim.SetBool("att",false);
        }
        else
        {
            anim.SetBool("att",true);
        }
    }

    void animAttack()
    {
        //anim.SetTrigger("Attack");
        anim.SetBool("att",true);
    }
}
