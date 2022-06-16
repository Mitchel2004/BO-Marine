using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject player;
    [SerializeField] float cameraSpeed = 100;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void FixedUpdate()
    {
        Camera();
    }

    void Camera()
    {
        float x = Input.GetAxis("Mouse X") * (cameraSpeed * Time.deltaTime);
        float y = Input.GetAxis("Mouse Y") * (cameraSpeed * Time.deltaTime);

        transform.RotateAround(player.transform.position, Vector3.up, x);

        /*if (transform.rotation.eulerAngles.y <= 45 || transform.rotation.eulerAngles.y >= 315)
        {
            transform.RotateAround(player.transform.position, Vector3.up, x);
        }
        else if (transform.rotation.eulerAngles.y < 180)
        {
            transform.RotateAround(player.transform.position, Vector3.down, 1);
        }
        else if (transform.rotation.eulerAngles.y > 180)
        {
            transform.RotateAround(player.transform.position, Vector3.up, 1);
        }*/

        if (transform.rotation.eulerAngles.x <= 45 || transform.rotation.eulerAngles.x >= 315)
        {
            transform.RotateAround(player.transform.position, Vector3.left, y);
        }
        else if (transform.rotation.eulerAngles.x < 180)
        {
            transform.RotateAround(player.transform.position, Vector3.right, -1);
        }
        else if (transform.rotation.eulerAngles.x > 180)
        {
            transform.RotateAround(player.transform.position, Vector3.left, -1);
        }

        Quaternion quaternion = transform.rotation;
        quaternion.eulerAngles = new Vector3(quaternion.eulerAngles.x, quaternion.eulerAngles.y, 0);
        transform.rotation = quaternion;
    }
}
