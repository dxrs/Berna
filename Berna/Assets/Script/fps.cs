using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class fps : MonoBehaviour
{
    //public Text fpstxt;
    public TextMeshProUGUI fpsnya;

    float pollingTime = 1f;
    float time;
    int frameCount;
    private void Start()
    {
        //Application.targetFrameRate = 60;
    }
    private void Update()
    {
        time += Time.deltaTime;

        frameCount++;
        if (time >= pollingTime)
        {
            int frameRate = Mathf.RoundToInt(frameCount / time);
            fpsnya.text = frameRate.ToString() + " fps";

            time -= pollingTime;
            frameCount = 0;
        }
    }
}
