using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerGuns : MonoBehaviour
{
    public static PlayerGuns playerGuns;

    public GameObject[] realWeapon;
    public bool isWeaponPickedUp;

    [SerializeField] Camera cam;
    [SerializeField] float pickRange;
    [SerializeField] LayerMask pickUpLayer;
    [SerializeField] Image[] GunsLogo;

    [Header("Pick Up Weapon")]
    public GameObject[] fakeWeapon;

    private void Awake()
    {
        playerGuns = this;
    }
    private void Start()
    {
        GunsLogo[0].enabled = false;
        GunsLogo[1].enabled = false;
        //loop nya nanti di pindah sini klo tambah senjata
        for (int j = 0; j < realWeapon.Length; j++) 
        {
            if (realWeapon[j].activeSelf) 
            {
                //print(j);
            }
        }
    }
    private void Update()
    {
        if (realWeapon[0].activeSelf || realWeapon[1].activeSelf) 
        {
            isWeaponPickedUp = true;
        }
       
        if (Input.GetKeyDown(KeyCode.E)) 
        {
            Ray ray = cam.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
            RaycastHit hit;
            if(Physics.Raycast(ray,out hit, pickRange, pickUpLayer)) 
            {
                // masih pke cara manual
                if (hit.transform.name == fakeWeapon[0].name)
                {
                    realWeapon[0].SetActive(true);
                    fakeWeapon[0].SetActive(false);
                    //logoDisplay
                    GunsLogo[0].enabled = true;
                    GunsLogo[1].enabled = false;
                    if (realWeapon[0].activeSelf == true) 
                    {
                        realWeapon[1].SetActive(false);
                        fakeWeapon[1].SetActive(true);
                    }
                    
                }
                if (hit.transform.name == fakeWeapon[1].name)
                {
                    realWeapon[1].SetActive(true);
                    fakeWeapon[1].SetActive(false);
                    //logoDisplay
                    GunsLogo[0].enabled = false;
                    GunsLogo[1].enabled = true;
                    if (realWeapon[1].activeSelf == true)
                    {
                        realWeapon[0].SetActive(false);
                        fakeWeapon[0].SetActive(true);
                    }

                }
            }
            
        }
    }
}
