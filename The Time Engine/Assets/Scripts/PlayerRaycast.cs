using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerRaycast : MonoBehaviour
{
    public RaycastHit hit;
    //Weapon damage
    public int rifleDPS;
    //Weapon fire rate
    public float rifleFireRate = 1;
    public bool rifleFire;
    public bool enoughRifleAmmo;
    //Ammo count
    public int rifleAmmoCounter;
    //Weapons
    public int weaponSelection;
    public bool flamethrower;
    public bool rifle;
    public bool revolver;
    //UI
    public RaycastHit hitShop;
    public bool interactableRange;
    //References
    public GameObject generalManager;
    public GameObject uIManager;
    public GameObject playerCamera;
    public GameObject impact;

    // Use this for initialization
    void Start()
    {
        rifleAmmoCounter = 100;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        Weapons();
        Ammo();
        Misc();
    }

    //Void containing weapons
    void Weapons()
    {
        //Rifle
        Debug.DrawRay(transform.position, transform.forward * 25, Color.magenta);
        if (Input.GetButton("Fire1"))
        {
            if (rifle == true)
            {
                if (rifleFire == true)
                {
                    if (enoughRifleAmmo == true)
                    {
                        rifleAmmoCounter -= 1;
                        rifleFire = false;
                        if (Physics.Raycast(transform.position, transform.forward, out hit, 1000f))
                        {
                            GameObject g = Instantiate(impact, hit.point, Quaternion.FromToRotation(Vector3.forward, hit.normal));
                            Destroy(g, 2);
                            if (hit.transform.tag == ("Pim"))
                            {
                                hit.transform.gameObject.GetComponent<Enemy>().health -= rifleDPS;
                            }
                        }
                    }
                }
            }
        }

        //WeaponSelection/UI
        if (flamethrower == true)
        {
            playerCamera.GetComponent<Flamethrower>().ActivateFlamethrower();
            uIManager.GetComponent<GeneralUI>().flamethrower = true;
        }
        else
        {
            uIManager.GetComponent<GeneralUI>().flamethrower = false;
        }

        if (revolver == true)
        {
            playerCamera.GetComponent<Revolver>().revolverOcelot();
            uIManager.GetComponent<GeneralUI>().revolver = true;
        }
        else
        {
            uIManager.GetComponent<GeneralUI>().revolver = false;
        }

        if (rifle == true)
        {
            uIManager.GetComponent<GeneralUI>().rifle = true;
        }
        else
        {
            uIManager.GetComponent<GeneralUI>().rifle = false;
        }
    }

    //Everything regarding ammo
    void Ammo()
    {
        rifleFireRate -= Time.deltaTime;
        if (rifleFireRate <= 0)
        {
            rifleFire = true;
            rifleFireRate = 0.1f;
        }

        if (rifleAmmoCounter <= 0)
        {
            enoughRifleAmmo = false;
        }
        else
        {
            enoughRifleAmmo = true;
        }
    }

    //All the stuff that doesn't fit into the other categories
    void Misc()
    {
        if (Input.GetButtonDown("WeaponSwap"))
        {
            weaponSelection += 1;
        }

        if (weaponSelection == 0)
        {
            rifle = true;
        }
        else
        {
            rifle = false;
        }

        if (weaponSelection == 1)
        {
            flamethrower = true;
        }
        else
        {
            flamethrower = false;
        }

        if (weaponSelection == 2)
        {
            revolver = true;
        }
        else
        {
            revolver = false;
        }

        if (weaponSelection == 3)
        {
            weaponSelection = 0;
        }
    }
}
