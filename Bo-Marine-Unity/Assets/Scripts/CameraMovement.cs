using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform cameraPoint;
    public float cameraSpeed = 100f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        Camera();
    }

    void Camera()
    {
        float interpolation = cameraSpeed * Time.deltaTime;

        Vector3 position = transform.position;
        position.y = Mathf.Lerp(transform.position.y, cameraPoint.position.y, interpolation);
        position.x = Mathf.Lerp(transform.position.x, cameraPoint.position.x, interpolation);

        transform.position = position;

        Quaternion quaternion = transform.rotation;
        quaternion.eulerAngles = new Vector3(quaternion.eulerAngles.x, quaternion.eulerAngles.y, 0);
        transform.rotation = quaternion;
    }
    // Volledig rond het character draaien.
    // Een limit voor het verticaal kijken.

}
