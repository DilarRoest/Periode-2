using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    void OnTriggerEnter(Collider trigger)
    {
        if (trigger.gameObject.name == ("Player"))
        {
            SceneManager.LoadScene("Boss Fight");
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Beach");
    }
}
