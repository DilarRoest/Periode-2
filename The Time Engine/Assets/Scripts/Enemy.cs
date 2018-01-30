using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Enemy : MonoBehaviour
{
    public int health;
    public float speed;
    public bool king;
    public Vector3 direction;
    public GameObject explosion;
    public GameObject playerCamera;
    public GameObject victory;
    private Transform player;

    // Use this for initialization
    void Start ()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
            GameObject g = Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(g, 3);
            if (king == true)
            {
                victory.SetActive(true);
            }
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
            playerCamera.GetComponent<PlayerRaycast>().health -= 25;
        }
    }
}
