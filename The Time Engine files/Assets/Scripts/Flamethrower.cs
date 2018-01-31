using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flamethrower : MonoBehaviour
{
    private RaycastHit hit;
    public GameObject vuurtje;
    public int flameDPS;
    private bool enoughAmmo;
    public float flamethrowerAmmo;

    // Use this for initialization
    void Start ()
    {
        flamethrowerAmmo = 100;
	}
	
	// Update is called once per frame
	void Update ()
    {

    }

    public void ActivateFlamethrower()
    {
        if (Input.GetAxisRaw("Flamethrower") == 1)
        {
            if (enoughAmmo == true)
            {
                GameObject f = Instantiate(vuurtje, transform.position, transform.rotation);
                flamethrowerAmmo -= Time.deltaTime * 10;
                Destroy(f, 0.15f);
                if (Physics.Raycast(transform.position, transform.forward, out hit, 15))
                {
                    if (hit.transform.tag == ("Pim"))
                    {
                        hit.transform.gameObject.GetComponent<Enemy>().health -= flameDPS;
                    }
                }
            }
        }

        if (flamethrowerAmmo <= 0)
        {
            enoughAmmo = false;
            flamethrowerAmmo = 0;
        }
        else
        {
            enoughAmmo = true;
        }
    }
}
