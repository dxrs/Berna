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

    [Header("Peluru")]
    [SerializeField] TextMeshProUGUI tmp_gunAmmo;


    private void Awake()
    {
        inGameUI = this;
    }
    private void Start()
    {
       
    }
    private void Update()
    {
        tmp_stamina.text = "Stamina : " + Mathf.RoundToInt(playerStamina);

        tmp_nyawa.text = "Nyawa : " + PlayerDestroy.playerCurrentHealth;

        //everyGunAmmo();
    }
    void everyGunAmmo() 
    {
        
        
        if (!PlayerGuns.playerGuns.fakeWeapon[0].activeSelf
            )
        {
            
            tmp_gunAmmo.text = "SMG : " + GunController.gunController.curAmmo;
        }
        if (!PlayerGuns.playerGuns.fakeWeapon[1].activeSelf
            )
        {
           
            tmp_gunAmmo.text = "Pistol : " + GunController.gunController.curAmmo;
        }
        //else {  tmp_gunAmmo.text = "No Gun"; }
        

    }
}
