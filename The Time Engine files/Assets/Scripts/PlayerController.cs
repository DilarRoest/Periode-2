using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public RaycastHit scan;
    public Vector3 v;
    public float speed;
    public float horizontal;
    public float vertical;
    public GameObject cameraObject;
    public Vector3 mouse;
    public Vector3 mouse2;
    public Rigidbody rigid;
    public Vector3 hight;
    public bool allowJump;
    public bool allowMovement;
    public int doubleJump = 2;


    // Update is called once per frame
    void Update()
    {
        // Player Movement 
        if (allowMovement == true)
        {
            horizontal = Input.GetAxis("Horizontal");
            vertical = Input.GetAxis("Vertical");
            v.x = horizontal;
            v.z = vertical;
            transform.Translate(v * Time.deltaTime * speed);

            // Mouse Movement
            mouse.y = Input.GetAxis("Mouse X");
            mouse2.x = -Input.GetAxis("Mouse Y");
            transform.Rotate(mouse);
            cameraObject.transform.Rotate(mouse2);
        }
    }
}