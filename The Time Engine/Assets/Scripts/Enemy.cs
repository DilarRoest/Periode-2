using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject explosion;
    public int health;

    // Use this for initialization
    void Start ()
    {
        health = 100;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
            GameObject g = Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(g, 3);
        }
    }
}
