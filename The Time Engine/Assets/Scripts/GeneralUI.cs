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
    public GameObject gameOver;
    public GameObject healthCounter;
    public GameObject healthCounterMisc;
    public bool rifle;
    public bool flamethrower;
    public bool revolver;

    
	// Update is called once per frame
	void Update ()
    {
        FlamethrowerActivation();
        RifleUIActivation();
        RevolverActivation();
        Health();
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

    public void Health()
    {
        healthCounter.GetComponent<Text>().text = playerCamera.GetComponent<PlayerRaycast>().health.ToString();
    }

    public void DeathUi()
    {
        gameOver.SetActive(true);
        rifle = false;
        flamethrower = false;
        revolver = false;
        healthDeactivate();
    }

    public void healthDeactivate()
    {
        healthCounter.SetActive(false);
        healthCounterMisc.SetActive(false);
    }
}
