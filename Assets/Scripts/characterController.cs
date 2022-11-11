using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterController : MonoBehaviour
{
    public Vector2 turn;
    Rigidbody rb;
    public float rb_jumpPower = 20f;
    public float rb_runningSpeed = 20f;
    public bool groundcheck;
   



    void Awake()
    {
      
    }


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        bool tryToJump = false;

        //Mouse Orientaion
        turn.x += Input.GetAxis("Mouse X");
        turn.y += Input.GetAxis("Mouse Y");
        transform.localRotation = Quaternion.Euler(0, turn.x, 0);

    




        if (Input.GetButton("Jump") && groundcheck == true)
        {
            rb.AddForce(transform.up * rb_jumpPower);
            print("Jumped");
            tryToJump = true;
        }


        if (Input.GetKey("w") && tryToJump == false && groundcheck== true)
        {

            rb.velocity = transform.forward * rb_runningSpeed;
        }


    }

    private void OnCollisionEnter(Collision other)
    {
        
        if(other.gameObject.tag == "Ground")
        {
            groundcheck = true;
            print("hjwhaujfv w");
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Ground")
        {
            groundcheck = false;

        }
    }
}

   
