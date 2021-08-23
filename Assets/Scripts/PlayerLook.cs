using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    private float mouseY;
    private float mouseX;
    public float mouseSensivity;
    private float xRotation = 0f;

    public Transform player;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        mouseX = Input.GetAxis("Mouse X") * mouseSensivity * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * mouseSensivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        player.Rotate(Vector3.up * mouseX);
    }
}
