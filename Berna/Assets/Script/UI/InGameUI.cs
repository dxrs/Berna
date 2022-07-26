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

    [Header("Bar Setup")]
    public Image StaminaBar;
    public Image HealthBar;



    private void Awake()
    {
        inGameUI = this;
    }
    private void Start()
    {
        tmp_timer.text = "00:00:00";
        isTimeStart = false;
    }
    private void Update()
    {
        if (playerStamina >= 100.0f) playerStamina = 100.0f;
        tmp_stamina.text =Mathf.RoundToInt(playerStamina).ToString();
        tmp_nyawa.text = "Nyawa : " + Mathf.RoundToInt(playerHealth);

        barSetup();
        
    }

    void barSetup()
    {
        StaminaBar.fillAmount = playerStamina/100;
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
            string strTimerPlaying =timePlay.ToString("mm':'ss':'ff");
            tmp_timer.text = strTimerPlaying;

            yield return null;
        }
    }
    #endregion

   

}
