using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour
{
    public static AudioScript instance;
    public AudioSource Source;
    public AudioClip Clip;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    void Update()
    {
        
    }

    public void SMG_Sound()
    {
        Source.PlayOneShot(Clip);
    }
}
