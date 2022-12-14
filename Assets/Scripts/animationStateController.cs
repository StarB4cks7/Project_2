using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationStateController : MonoBehaviour
{
    Animator animator;


    private bool isJumbing;
    private bool isGrounded;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

  
        
    }

    // Update is called once per frame
    void Update()
    {
        //Local bool is equal to bool of animation
        bool isRunning = animator.GetBool("IsRunning");
        //forward presses
        bool forwardPressed = Input.GetKey("w");

        //If Player presses W runnuing animation plays
        if (!isRunning && forwardPressed && isJumbing==false)
        {
            animator.SetBool("IsRunning", true);

           
        }

        if (isGrounded == false)
        {
            animator.SetBool("IsRunning", false);
        }
        

        //Resets Boolien to false 
        if (isRunning && !forwardPressed)
        {
            animator.SetBool("IsRunning", false);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        isGrounded = true;
        Debug.Log("Groudn check animator");
        animator.SetBool("IsJumping", false);

    }

    //Just landed sets jumping at false
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Ground")
        {
            isJumbing = false;
            Debug.Log("landed");
        }
    }

    //
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Ground")
        {
            isGrounded = false;
            animator.SetBool("IsJumping", true);
            isJumbing = true;

        }
    }

    
}
