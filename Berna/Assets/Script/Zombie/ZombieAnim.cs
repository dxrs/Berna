using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAnim : MonoBehaviour
{
    public Animator anim;

    void Update()
    {
        anim.SetFloat("Speed",ZombieAi.velo, 0.1f, Time.deltaTime);
    }
}
