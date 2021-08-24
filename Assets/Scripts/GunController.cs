using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public Gun gun;
    public PlayerLook playerLook;
    public FPMovement playerMovement;

    public float SwayAmount;
    public float SwaySmoothing;
    public float SwayResetSmoothing;
    public float MovementSwaySmoothing;

    public Vector2 MovementSway;
    public Vector2 swayClamp;

    private Vector3 newWeaponRotation;
    private Vector3 newWeaponRotationVelocity;
    private Vector3 targetWeaponRotation;
    private Vector3 targetWeaponRotationVelocity;

    private Vector3 newWeaponMovementRotation;
    private Vector3 newWeaponMovementRotationVelocity;
    private Vector3 targetWeaponMovementRotation;
    private Vector3 targetWeaponMovementRotationVelocity;

    private void Update()
    {
        targetWeaponRotation.y += SwayAmount * playerLook.mouseX * Time.deltaTime;
        targetWeaponRotation.x += SwayAmount * playerLook.mouseY * Time.deltaTime;

        targetWeaponRotation.x = Mathf.Clamp(targetWeaponRotation.x, -swayClamp.x, swayClamp.x);
        targetWeaponRotation.y = Mathf.Clamp(targetWeaponRotation.y, -swayClamp.y, swayClamp.y);
        targetWeaponRotation.z = targetWeaponRotation.y;

        targetWeaponRotation = Vector3.SmoothDamp(targetWeaponRotation, Vector3.zero, ref targetWeaponRotationVelocity, SwayResetSmoothing);
        newWeaponRotation = Vector3.SmoothDamp(newWeaponRotation, targetWeaponRotation, ref newWeaponRotationVelocity, SwaySmoothing);


        targetWeaponMovementRotation.z = MovementSway.x * playerMovement.MovementInput.x;
        targetWeaponMovementRotation.x = MovementSway.y * playerMovement.MovementInput.y;

        targetWeaponMovementRotation = Vector3.SmoothDamp(targetWeaponMovementRotation, Vector3.zero, ref targetWeaponMovementRotationVelocity, MovementSwaySmoothing);
        newWeaponMovementRotation = Vector3.SmoothDamp(newWeaponMovementRotation, targetWeaponMovementRotation, ref newWeaponMovementRotationVelocity, MovementSwaySmoothing);

        gun.transform.localRotation = Quaternion.Euler(newWeaponRotation + newWeaponMovementRotation);
    }
}
