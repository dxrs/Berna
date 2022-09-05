using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Z_Hitted : MonoBehaviour
{

    [Header("Hitted Effect")]
    public float blinkIntensity;
    public float blinkDuration;
    float blinkTimer;
    SkinnedMeshRenderer meshRender;

    // Start is called before the first frame update
    void Start()
    {
        meshRender =GetComponent<SkinnedMeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        blinkTimer -= Time.deltaTime;
        float lerp = Mathf.Clamp01(blinkTimer/blinkDuration);
        float intensity = lerp * blinkIntensity;
        meshRender.material.color = Color.white * intensity;
    }

    public void shooted()
    {
        blinkTimer = blinkDuration;
    }
}