using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    public Transform player;

    public float mouseSens = 100f;
    public float maxCameraAngle = 60f;

    float xRotation;

    void Start()
    {
        //lock cursor in center and hide it
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseXpos = Input.GetAxis("Mouse X") * Time.deltaTime * mouseSens;
        float mouseYpos = Input.GetAxis("Mouse Y") * Time.deltaTime * mouseSens;

        xRotation -= mouseYpos;
        xRotation = Mathf.Clamp(xRotation, -maxCameraAngle, maxCameraAngle);

        //transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        player.Rotate(Vector3.up * mouseXpos);
    }
}
