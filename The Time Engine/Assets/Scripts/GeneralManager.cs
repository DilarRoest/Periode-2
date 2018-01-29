using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralManager : MonoBehaviour
{
    public GameObject playerCamera;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void RifleAmmoRegain(int ammo)
    {
        playerCamera.GetComponent<PlayerRaycast>().rifleAmmoCounter += ammo;
    }

    public void FlamethrowerFeulRegain(int fuel)
    {
        playerCamera.GetComponent<Flamethrower>().flamethrowerAmmo += fuel;
    }

    public void Medkit(int health)
    {
        playerCamera.GetComponent<PlayerRaycast>().health += health;
    }
}
