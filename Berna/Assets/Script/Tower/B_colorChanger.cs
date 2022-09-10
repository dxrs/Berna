using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B_colorChanger : MonoBehaviour
{
    public static B_colorChanger instance;
    MeshRenderer warnaAsli;

    [SerializeField]
    float[] stoppoint = new float[5];
    public float intensity;

    bool sidePos = true;
    public bool shotEnable;


    int x;

    void Awake()
    {
        x=0;
        if(instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        warnaAsli = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y<39||transform.position.x==stoppoint[x])
        {
            if(x+1<stoppoint.Length)
            {
                x++;
            }
            
            colorAsli();
            
                
        }
        if(transform.position.x!=stoppoint[x] && transform.position.y==39)
        {
            colorWhite();
        }
        warnaAsli.material.color = Color.white * intensity;
    }

    void colorWhite()
    {
        intensity = 5;
    }
    void colorAsli()
    {
        intensity = 0;
    }

    void kodingCoba()
    {
        
    }
    IEnumerator test()
    {
        while (true)
        {
            if(x <= stoppoint.Length-1)
            {
                kodingCoba();
            }
            yield return null;
        }
    }
}
