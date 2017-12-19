using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GeneralUI : MonoBehaviour
{
    public GameObject playerCamera;
    public GameObject rifleCounter;
    public GameObject rifleMisc;
    public GameObject flamethrowerCounter;
    public GameObject flamethrowerMisc;
    public GameObject revolverCounter;
    public GameObject revolverMisc;
    public bool rifle;
    public bool flamethrower;
    public bool revolver;

    // Use this for initialization
    void Start ()
    {

    }
	
	// Update is called once per frame
	void Update ()
    {
        FlamethrowerActivation();
        RifleUIActivation();
        RevolverActivation();
    }

    public void RifleUIActivation ()
    {
        if (rifle == true)
        {
            rifleMisc.SetActive(true);
            rifleCounter.SetActive(true);
            rifleCounter.GetComponent<Text>().text = playerCamera.GetComponent<PlayerRaycast>().rifleAmmoCounter.ToString();
        }
        else
        {
            rifleCounter.SetActive(false);
            rifleMisc.SetActive(false);
        }
    }

    public void FlamethrowerActivation()
    {
        if (flamethrower == true)
        {
            flamethrowerMisc.SetActive(true);
            flamethrowerCounter.SetActive(true);
            flamethrowerCounter.GetComponent<Text>().text = playerCamera.GetComponent<Flamethrower>().flamethrowerAmmo.ToString("F0");
        }
        else
        {
            flamethrowerCounter.SetActive(false);
            flamethrowerMisc.SetActive(false);
        }
    }

    public void RevolverActivation()
    {
        if (revolver == true)
        {
            revolverMisc.SetActive(true);
            revolverCounter.SetActive(true);
            revolverCounter.GetComponent<Text>().text = playerCamera.GetComponent<Revolver>().revolverAmmo.ToString();
        }
        else
        {
            revolverMisc.SetActive(false);
            revolverCounter.SetActive(false);
        }
    }        
}
