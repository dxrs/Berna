using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ScoreManager : MonoBehaviour
{
    public static ScoreManager scoreManager;

    public float Scorenya;
    public float comboScore;
    [SerializeField] TextMeshProUGUI tmp_score;
    float curScore;

    private void Awake()
    {
        scoreManager = this;
    }

    private void Start()
    {
        //comboScore = 100f;
    }
    private void Update()
    {
        //curScore = comboScore;
    }



}
