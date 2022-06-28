using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    [Header("Camera Settings")]
    [SerializeField] float cameraSenX;
    [SerializeField] float cameraSenY;

    [Header("Transform References")]
    [SerializeField] Transform followTransform;
    public bool cursorVisible;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        cursorVisible = false;
    }

    void Update()
    {
        CameraRotation();
    }

    void CameraRotation()
    {
        //Get input
        float mouseX = Input.GetAxis("Mouse X") * Time.deltaTime;
        float mouseY = -Input.GetAxis("Mouse Y") * Time.deltaTime;

        //Rotate the follow transform based on input
        followTransform.transform.rotation *= Quaternion.AngleAxis(mouseX * cameraSenX, Vector3.up);
        followTransform.transform.rotation *= Quaternion.AngleAxis(mouseY * cameraSenY, Vector3.right);

        //Clamping looking Up/Down 
        var angles = followTransform.transform.localEulerAngles;
        angles.z = 0;

        var angle = followTransform.transform.localEulerAngles.x;

        if (angle > 180 && angle < 340)
        {
            angles.x = 340;
        }
        else if (angle < 180 && angle > 40)
        {
            angles.x = 40;
        }

        followTransform.transform.localEulerAngles = angles;

        //Rotate player with camera
        transform.rotation = Quaternion.Euler(0, followTransform.transform.rotation.eulerAngles.y, 0);
        //Reste the y rotation of look transform
        followTransform.transform.localEulerAngles = new Vector3(angles.x, 0, 0);
    }
}
