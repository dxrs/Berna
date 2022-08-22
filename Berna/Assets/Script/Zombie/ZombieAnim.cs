using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAnim : MonoBehaviour
{
    public Animator anim;

    void Update()
    {
        anim.SetFloat("Speed",ZombieAi.velo, 0.1f, Time.deltaTime);
        if(ZombieAi.attak == "serang")
        {
            animAttack();
        }
        else
        {
            anim.SetBool("att",false);
        }
    }

    void animAttack()
    {
        //anim.SetTrigger("Attack");
        anim.SetBool("att",true);
    }
}
