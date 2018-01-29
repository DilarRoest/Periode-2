using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    public GameObject player;
    public GameObject managers;
    public int amount;
    public bool rifleAmmo;
    public bool flamethrowerFuel;
    public bool medkit;

	// Use this for initialization
	void Start ()
    {
        
    }
	
	// Update is called once per frame
	void Update ()
    {
        
    }

    public void OnTriggerEnter(Collider hit)
    {
        if (hit.gameObject.name == ("Player"))
        {
            if (rifleAmmo == true)
            {
                managers.GetComponent<GeneralManager>().RifleAmmoRegain(amount);
                Destroy(gameObject);
            }
            if (flamethrowerFuel == true)
            {
                managers.GetComponent<GeneralManager>().FlamethrowerFeulRegain(amount);
                Destroy(gameObject);
            }
            if (medkit == true)
            {
                managers.GetComponent<GeneralManager>().Medkit(amount);
            }
        }
    }
}
