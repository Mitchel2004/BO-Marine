using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    LineRenderer lr;

    public Transform range;
    public Animator animator;

    [SerializeField] float walkSpeed = 10f;
    [SerializeField] float walkBackwardsSpeed = 5f;
    [SerializeField] float rotateSpeed = 100f;

    [SerializeField] float jumpForce = 5f;
    [SerializeField] float jumpHeight = 0.1f;
    bool canJump;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        lr = GetComponent<LineRenderer>();
    }

    void FixedUpdate()
    {
        Walk();
        GroundedCheck();
        JumpAnimation();
        Pointer();
    }

    //Makes player walk with the axises 
    void Walk()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        animator.SetFloat("Speed", z);
        
        transform.Rotate(new Vector3(0, x, 0) * (rotateSpeed * Time.deltaTime));
        //collisioncheck op tag fog

        if (z > 0)
        {
            transform.Translate(new Vector3(0, 0, z) * (walkSpeed * Time.deltaTime));
        }
        else
        {
            transform.Translate(new Vector3(0, 0, z) * (walkBackwardsSpeed * Time.deltaTime));
        }  
    }

    //Checks if the player is grounded
    void GroundedCheck()
    {
        RaycastHit hit;
        Ray ray = new Ray(transform.position, Vector3.down);

        if (Physics.Raycast(ray, out hit, jumpHeight))
        {
            if (hit.collider == null)
            {
                canJump = false;
            }
            else
            {
                canJump = true;
            }
        }
    }

    //Animation for Jumping
    void JumpAnimation()
    {
        if (Input.GetButton("Jump") && canJump)
        {
            StartCoroutine(Jump()); // Delay for jumping
            animator.SetBool("Jump", true);
        }
        else
        {
            animator.SetBool("Jump", false);
        }
    }

    //Calculate the delay
    IEnumerator Jump()
    {
        yield return new WaitForSeconds(0.25f);

        rb.velocity = new Vector3(0, jumpForce, 0);
        canJump = false;
    }

    //Aim with a linerenderer
    void Pointer()
    {
        lr.SetPosition(0, new Vector3(transform.position.x, range.transform.position.y, transform.position.z));

        if (schieten.canFire)
        {
            lr.SetPosition(1, new Vector3(range.transform.position.x, range.transform.position.y, range.transform.position.z));
        }
        else
        {
            lr.SetPosition(1, new Vector3(transform.position.x, range.transform.position.y, transform.position.z));
        }
    }
}
