using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ScoreManager : MonoBehaviour
{
    public static ScoreManager scoreManager;

    public float Scorenya;
    public float comboScore;
    public float curComboValue;
    public bool isCombo;
    [SerializeField] TextMeshProUGUI tmp_score;
    float curScore;

    private void Awake()
    {
        scoreManager = this;
    }

    private void Start()
    {
        //comboScore = 100f;
        //StartCoroutine(cuk2());
    }
    private void Update()
    {
     
        curScore = Scorenya;
        curComboValue = comboScore-2;
        StartCoroutine(cuk());
        if (isCombo) 
        {
            
        }
        //StartCoroutine(cuk2());
    }
     IEnumerator cuk() 
    {
        if (isCombo) 
        {
            yield return new WaitForSeconds(0.0007f);
            isCombo = false;
        }
    }
    IEnumerator cuk2() 
    {
        if (isCombo == true) 
        {
            yield return new WaitForSeconds(0.1f);
            Scorenya += comboScore; //50*2, 100*3, dsb
            
        }
    }


}
