using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;

public class InGameUI : MonoBehaviour
{
    public static InGameUI inGameUI;

    [Header("Player Health")]
    public float playerHealth = 100f; // di ubah ke int jg bs
    [SerializeField] TextMeshProUGUI tmp_nyawa;

    [Header("Player Stamina")]
    public float playerStamina=100f;
    [SerializeField] TextMeshProUGUI tmp_stamina;

    [Header("Timer Counter")]
    [SerializeField] TextMeshProUGUI tmp_timer;
    [SerializeField] private bool isTimeStart;
    TimeSpan timePlay;
    float timeStartValue;



    private void Awake()
    {
        inGameUI = this;
    }
    private void Start()
    {
        tmp_timer.text = "Time : 00:00:00";
        isTimeStart = false;
    }
    private void Update()
    {
        if (playerStamina >= 100.0f) playerStamina = 100.0f;
        tmp_stamina.text = "Stamina : " + Mathf.RoundToInt(playerStamina);
        tmp_nyawa.text = "Nyawa : " + Mathf.RoundToInt(playerHealth);
        if (!PlayerManager.playerManager.gameOver) 
        {
            
        }
        

        
    }

    //timer
    #region
    public void timeStart() // -> di pangil pas trigger sm pintu;
    {
       
        isTimeStart = true;
        timeStartValue = 0f;
        StartCoroutine(timeStarting());
    }

    public void timeEnd() //-> di panggil pas game over
    {
        isTimeStart = false;
    }

    IEnumerator timeStarting() 
    {
        while (isTimeStart ) 
        {
            timeStartValue += Time.deltaTime;
            timePlay = TimeSpan.FromSeconds(timeStartValue);
            string strTimerPlaying = "Time : " + timePlay.ToString("mm':'ss':'ff");
            tmp_timer.text = strTimerPlaying;

            yield return null;
        }
    }
    #endregion

}
