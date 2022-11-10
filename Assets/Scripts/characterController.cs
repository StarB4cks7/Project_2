using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterController : MonoBehaviour
{
    public Vector2 turn;
    Rigidbody rb;
    public float rb_jumpPower = 20f;
    public float rb_runningSpeed = 20f;


     void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        //Mouse Orientaion
        turn.x += Input.GetAxis("Mouse X");
        turn.y += Input.GetAxis("Mouse Y");
        transform.localRotation = Quaternion.Euler(0, turn.x, 0);

        if (Input.GetButton("Jump"))
        {
            rb.AddForce(transform.up * rb_jumpPower);
        }


        if (Input.GetKey("w"))
        {

            rb.velocity = transform.forward * rb_runningSpeed;
        }


    }

   
