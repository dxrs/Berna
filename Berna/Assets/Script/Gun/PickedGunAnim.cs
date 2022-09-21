using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickedGunAnim : MonoBehaviour
{
    [SerializeField] bool diPutar;
    [SerializeField] float sineSpeed;
    [SerializeField] float sinePower;
    [SerializeField] float rotSpeed;

    float randomOffset;

    Vector3 pos;

    private void Start()
    {
        randomOffset = (int)Random.Range(0, 3);
        pos = transform.position;
    }

    private void Update()
    {
        if (!diPutar) 
        {
            transform.position = pos + new Vector3(
            Mathf.Cos(sineSpeed * Time.time + randomOffset) * sinePower,
            Mathf.Sin(sineSpeed * Time.time + randomOffset) * sinePower,
            0.0f);
        }
        else 
        {
            transform.Rotate(Vector3.up, rotSpeed*Time.deltaTime);
        }
        
    }
}
