using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityChanDemo1 : MonoBehaviour {
    public float forwardspeed;
    public float backwardspeed;
    public float rotationspeed;
    public float jumppower;
    private Animator animator;
    private Rigidbody rb;
    private float animationspeed = 1.5f;
    private Vector3 velocity;
    private AnimatorStateInfo currentBaseState;

    static int runState = Animator.StringToHash("Base Layer.Locomotion");

    // Use this for initialization
    void Start() {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate() {
        animator.speed = animationspeed;
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        animator.SetFloat("Speed", v);
        animator.SetFloat("Side", h);
        velocity = new Vector3(0, 0, v);
        velocity = transform.TransformDirection(velocity);
        currentBaseState = animator.GetCurrentAnimatorStateInfo(0);
        animator.SetBool("Jump", false);
        rb.useGravity = true;
       
        if (v > 0.1)
        {
            velocity *= forwardspeed;
        }else if (v < -0.1)
        {
            velocity *= backwardspeed;
        }
        transform.localPosition += velocity * Time.fixedDeltaTime;
        transform.Rotate(0, h * rotationspeed, 0);
        if (Input.GetButtonDown("Jump"))
        {
            if (currentBaseState.nameHash  == runState)
            {
                if (!animator.IsInTransition(0)) {
                    animator.SetBool("Jump", true);
                    rb.useGravity = false;
                    rb.AddForce(Vector3.up * jumppower, ForceMode.Impulse);
                }
            } 
        }
        

    }
}
          /* if (Input.GetKey("up"))
          {
              
              transform.position += transform.forward * 0.05f;
              animator.SetBool("is_running", true);
            if (Input.GetKeyDown("space"))
            {
                animator.SetBool("running_jumping", true);
                rb.AddRelativeForce(0, 1, 0, ForceMode.Impulse);
            }
            else
            {
                animator.SetBool("running_jumping", false);
            }
        }
        else
          {
              animator.SetBool("is_running", false);
          }
          if (Input.GetKey("right"))
          {
              transform.Rotate(0, 10, 0);
          }
          if (Input.GetKey("left"))
          {
              transform.Rotate(0, -10, 0);

          }
        if (Input.GetKey("down"))
        {
            transform.position -= transform.forward * 0.01f;
            animator.SetBool("back_going", true);
        }
        else
        {
            animator.SetBool("back_going", false);
        }
        if (Input.GetKeyDown("space"))
        {
            animator.SetInteger("Idle_jumping", 1);
            rb.AddRelativeForce(0, 6, 0, ForceMode.Impulse);
        }
        else if(Input.GetKey("up"))
        {
            animator.SetInteger("Idle_jumping", 1);
        }else
        {
            animator.SetInteger("Idle_jumping", 0);
        }
        
    }
}
*/
