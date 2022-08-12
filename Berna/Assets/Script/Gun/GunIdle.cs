using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunIdle : MonoBehaviour
{
    public static GunIdle gunIdle;

    [SerializeField] float rotSpeed;

    Quaternion rot;

    private void Awake()
    {
        if (gunIdle == null) { gunIdle = this; }
    }

    private void Start()
    {
        rot = transform.localRotation;
    }

    private void Update()
    {
       // transform.localRotation=
    }
}
