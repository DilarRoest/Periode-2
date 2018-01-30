using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Revolver : MonoBehaviour
{
    public GameObject bullet;
    private RaycastHit hit;
    public int revolverDPS;
    public bool allowFire;
    public int revolverAmmo = 6;
    public AudioSource source;

    // Use this for initialization
    void Start ()
    {
        allowFire = true;
    }
	
	// Update is called once per frame
	void Update ()
    {

    }

    public void revolverOcelot()
    {
        Debug.DrawRay(transform.position, transform.forward * 25, Color.magenta);
        if (Input.GetButtonDown("Fire1"))
        {
            if (allowFire == true)
            {
                source.Play();
                revolverAmmo -= 1;
                if (Physics.Raycast(transform.position, transform.forward, out hit, 1000f))
                {
                    GameObject g = Instantiate(bullet, hit.point, Quaternion.FromToRotation(Vector3.forward, hit.normal));
                    Destroy(g, 2);
                    if (hit.transform.tag == ("Pim"))
                    {
                        hit.transform.gameObject.GetComponent<Enemy>().health -= revolverDPS;
                    }
                }
            }
        }

        if (revolverAmmo <= 0)
        {
            allowFire = false;
        }
        else
        {
            allowFire = true;
        }
    }
}
