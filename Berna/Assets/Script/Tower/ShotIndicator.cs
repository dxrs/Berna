using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotIndicator : MonoBehaviour
{
    public ShotIndicator instance;
    MeshRenderer meshRender;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        meshRender = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ligtOn()
    {
        meshRender.material.color = Color.white * 10 ;
    }
    public void ligtOff()
    {
        meshRender.material.color = Color.white * 0 ;
    }
}
