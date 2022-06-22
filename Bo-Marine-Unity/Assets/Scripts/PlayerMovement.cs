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

    void Walk()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        
        if ((z > 0.1 || z < -0.1) && canJump)
        {
            animator.CrossFade("Run", 0f);
        }
        else if ((z > 0 || z < 0) && canJump)
        {
            animator.CrossFade("Run Stop", 0.1f);
        }

        transform.Rotate(new Vector3(0, x, 0) * (rotateSpeed * Time.deltaTime));
        transform.Translate(new Vector3(0, 0, z) * (walkSpeed * Time.deltaTime));
    }

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

    void JumpAnimation()
    {
        if (Input.GetKey(KeyCode.Space) && canJump)
        {
            StartCoroutine(Jump());
            animator.CrossFade("Jump", 0f);
        }
    }

    IEnumerator Jump()
    {
        yield return new WaitForSeconds(0.25f);

        rb.velocity = new Vector3(0, jumpForce, 0);
        canJump = false;
    }

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
