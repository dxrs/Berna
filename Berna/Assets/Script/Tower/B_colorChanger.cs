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
        if(transform.position.y<39)
        {
            belumSiap();   
        }
        if(transform.position.y==39)
        {
            siap();
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

    void siap()
    {
        if(transform.position.x==stoppoint[0])
        {
            colorAsli();
        }
        else if(transform.position.x==stoppoint[1])
        {
            colorAsli();
            print("asdfa");
        }
        else if(transform.position.x==stoppoint[2])
        {
            colorAsli();
        }
        else if(transform.position.x==stoppoint[3])
        {
            colorAsli();
        }
        else if(transform.position.x==stoppoint[4])
        {
            colorAsli();
        }
        else
        {
            colorWhite();
        }
    }

    void belumSiap()
    {
        colorAsli();
    }

    void kodingCoba()
    {
        if(x>=stoppoint.Length-1)
        {
            return;
        }
        x++;
    }
    IEnumerator test()
    {
        while (true)
        {
            if(transform.position.x == stoppoint[x])
            {
                kodingCoba();
            }
        }
    }
}
