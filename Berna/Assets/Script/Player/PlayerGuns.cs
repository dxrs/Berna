using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGuns : MonoBehaviour
{
    public static PlayerGuns playerGuns;

    public GameObject[] realWeapon;
    public bool isWeaponPickedUp;

    [SerializeField] Camera cam;
    [SerializeField] float pickRange;
    [SerializeField] LayerMask pickUpLayer;
    [SerializeField] BoxCollider door;

    [Header("Pick Up Weapon")]
    public GameObject[] fakeWeapon;

    private void Awake()
    {
        playerGuns = this;
    }
    private void Start()
    {
        //loop nya nanti di pindah sini klo tambah senjata
        for (int j = 0; j < realWeapon.Length; j++) 
        {
            if (realWeapon[j].activeSelf) 
            {
                //print(j);
            }
        }

        door.isTrigger = false;
    }
    private void Update()
    {
        if (realWeapon[0].activeSelf || realWeapon[1].activeSelf) 
        {
            isWeaponPickedUp = true;
        }

        if (!isWeaponPickedUp || PlayerManager.playerManager.gameStarted) 
        {
            StartCoroutine(waitToClose());
        }
        if(isWeaponPickedUp && !PlayerManager.playerManager.gameStarted) 
        {
            door.isTrigger = true;
        }

        pickWeapon();
    }

    void pickWeapon() 
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray ray = cam.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, pickRange, pickUpLayer))
            {

                //Debug.Log("Hit : " + hit.transform.name);

                // masih pke cara manual
                if (hit.transform.name == fakeWeapon[0].name)
                {

                    //print("dapat smg");
                    //Debug.Log("senjata ammo " + GunController.gunController.curAmmo);
                    realWeapon[0].SetActive(true);
                    fakeWeapon[0].SetActive(false);
                    if (realWeapon[0].activeSelf == true)
                    {

                        //InGameUI.inGameUI.timeStart();
                        realWeapon[1].SetActive(false);
                        fakeWeapon[1].SetActive(true);


                    }

                }
                if (hit.transform.name == fakeWeapon[1].name)
                {

                    realWeapon[1].SetActive(true);
                    fakeWeapon[1].SetActive(false);
                    if (realWeapon[1].activeSelf == true)
                    {

                        realWeapon[0].SetActive(false);
                        fakeWeapon[0].SetActive(true);




                    }

                }
            }

        }
    }

    IEnumerator waitToClose() 
    {
        yield return new WaitForSeconds(1f);
        door.isTrigger = false;
    }
}
