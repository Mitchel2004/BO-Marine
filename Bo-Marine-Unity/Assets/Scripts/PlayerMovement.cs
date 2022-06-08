using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    LineRenderer lr;

    public Transform range;

    [SerializeField] float cameraSpeed = 10;
    [SerializeField] float walkSpeed = 10;
    [SerializeField] float jumpForce = 10;
    [SerializeField] float jumpHeight = 0.5f;
    bool canJump;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        lr = GetComponent<LineRenderer>();

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void FixedUpdate()
    {
        Spectate();
        Walk();
        GroundedCheck();
        Jump();
        Pointer();
    }

    void Walk()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        transform.Translate(new Vector3(x, 0, z) * (walkSpeed * Time.deltaTime));
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

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            rb.velocity = new Vector3(0, jumpForce, 0);
            canJump = false;
        }
    }

    void Spectate()
    {
        float mouseX = Input.GetAxis("Mouse X");

        transform.Rotate(0, mouseX * (cameraSpeed * Time.deltaTime), 0);
    }

    void Pointer()
    {
        float rangeZ = transform.FindChild("Range").position.z;

        if (schieten.kanVuren)
        {
            rangeZ = 100;
        }
        else
        {
            rangeZ = 0;
        }

        lr.SetPosition(0, new Vector3(transform.position.x, transform.position.y, transform.position.z));
        lr.SetPosition(1, new Vector3(range.transform.position.x, range.transform.position.y, range.transform.position.z));
    }
}
