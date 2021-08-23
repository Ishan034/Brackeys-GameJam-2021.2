using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed;
    public float gravity = 9.8f;
    public float jumpHeight;

    public Transform checkPos;
    private float checkRadius = 0.1f;
    public LayerMask groundLayer;

    Vector3 velocity;

    bool isGrounded;

    private void Update()
    {
        isGrounded = Physics.CheckSphere(checkPos.position, checkRadius, groundLayer);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -1f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -1f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}
