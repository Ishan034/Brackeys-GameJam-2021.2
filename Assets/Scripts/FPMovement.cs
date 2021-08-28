using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPMovement : MonoBehaviour
{
    public CharacterController controller;

    public Vector2 MovementInput { get; private set; }

    public float speed;
    public float gravity = 9.8f;
    public float jumpHeight;
    public float stepSoundInterval = 0.2f;
    private bool playSteps = false;

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

        MovementInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        if (isGrounded && (MovementInput.x != 0 || MovementInput.y != 0) && !playSteps)
        {
            playSteps = true;
            StartCoroutine(Footsteps());
        }
        else if ( (!isGrounded || (MovementInput.x == 0 && MovementInput.y == 0) ) && playSteps)
        {
            playSteps = false;
            StopAllCoroutines();
        }

        Vector3 move = transform.right * MovementInput.x + transform.forward * MovementInput.y;

        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            AudioManager.Instance.Play("PlayerJump");

            velocity.y = Mathf.Sqrt(jumpHeight * -1f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }

    private IEnumerator Footsteps()
    {
        AudioManager.Instance.Play("PlayerFootSteps");

        yield return new WaitForSeconds(stepSoundInterval);
        StartCoroutine(Footsteps());
    }
}
