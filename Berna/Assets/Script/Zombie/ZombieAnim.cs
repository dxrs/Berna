using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAnim : MonoBehaviour
{
    string state;
    public Animator anim;
    int test;
   
    void Start()
    {
        //walkAnim();
    }

    void Update()
    {
        state = ZombieAi.animaState;
        print(state);
        if(state == "Idle")
        {
            IdleAnim();
        }
        else if(state == "Patroling")
        {
            walkAnim();
        }
        else if(state == "Chasing")
        {

        }
        else if(state == "Attacking")
        {

        }
    }

    void walkAnim()
    {
        anim.SetTrigger("Walk");
    }

    void IdleAnim()
    {
        anim.SetTrigger("Idle");
    }

    void chaseAnim()
    {

    }

    void AttackAnim()
    {

    }
}
