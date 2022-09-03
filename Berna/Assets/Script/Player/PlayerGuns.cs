using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGuns : MonoBehaviour
{
    public static PlayerGuns playerGuns;

    public GameObject[] realWeapon;

    [SerializeField] Camera cam;
    [SerializeField] float pickRange;
    [SerializeField] LayerMask pickUpLayer;

    [Header("Pick Up Weapon")]
    [SerializeField] GameObject[] fakeWeapon;

    private void Start()
    {
        //loop nya nanti di pindah sini klo tambah senjata
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) 
        {
            Ray ray = cam.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
            RaycastHit hit;
            if(Physics.Raycast(ray,out hit, pickRange, pickUpLayer)) 
            {
                //Debug.Log("Hit : " + hit.transform.name);

                // masih pke cara manual
                if (hit.transform.name == fakeWeapon[0].name) 
                {
                    //print("dapat smg");
                    realWeapon[0].SetActive(true);
                    fakeWeapon[0].SetActive(false);
                    if (realWeapon[1].activeSelf == true) 
                    {
                        realWeapon[1].SetActive(false);
                        fakeWeapon[1].SetActive(true);
                    }
                    
                }
                if (hit.transform.name == fakeWeapon[1].name)
                {
                    //print("dapat smg");
                    realWeapon[1].SetActive(true);
                    fakeWeapon[1].SetActive(false);
                    if (realWeapon[0].activeSelf == true)
                    {
                        realWeapon[0].SetActive(false);
                        fakeWeapon[0].SetActive(true);
                    }

                }
            }
            
        }
    }
}
