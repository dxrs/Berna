using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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


    private void Awake()
    {
        inGameUI = this;
    }

    private void Update()
    {
        tmp_stamina.text = "Stamina : " + Mathf.RoundToInt(playerStamina);
    }
}
