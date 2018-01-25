using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject explosion;
    private Transform player;
    public Vector3 direction;
    public int health;
    public float speed;
    public GameObject playerCamera;

    // Use this for initialization
    void Start ()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Transform>();
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

    void OnTriggerStay(Collider trigger)
    {
        if (trigger.name == ("Player"))
        {
            GetHim();
        }
    }

    void GetHim()
    {
        direction.x = player.position.x;
        direction.z = player.position.z;
        direction.y = transform.position.y;
        transform.LookAt(direction);
        transform.Translate(new Vector3(0, 0, 2) * speed);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == ("Player"))
        {
            playerCamera.GetComponent<PlayerRaycast>().health -= 10;
        }
    }

}
