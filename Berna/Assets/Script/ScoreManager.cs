using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ScoreManager : MonoBehaviour
{
    public static ScoreManager scoreManager;

    public float comboScore;
    [SerializeField] TextMeshProUGUI tmp_score;
    float curScore;

    private void Awake()
    {
        scoreManager = this;
    }



}
