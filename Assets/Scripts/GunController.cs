using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public Gun gun;
    public PlayerLook playerLook;

    public float SwayAmount;
    public float SwaySmoothing;
    public float SwayResetSmoothing;

    public float swayClampX;
    public float swayClampY;

    private Vector3 newWeaponRotation;
    private Vector3 newWeaponRotationVelocity;
    private Vector3 targetWeaponRotation;
    private Vector3 targetWeaponRotationVelocity;

    private void Update()
    {
        targetWeaponRotation.y += SwayAmount * playerLook.mouseX * Time.deltaTime;
        targetWeaponRotation.x += SwayAmount * playerLook.mouseY * Time.deltaTime;

        targetWeaponRotation.x = Mathf.Clamp(targetWeaponRotation.x, -swayClampX, swayClampX);
        targetWeaponRotation.y = Mathf.Clamp(targetWeaponRotation.y, -swayClampY, swayClampY);

        targetWeaponRotation = Vector3.SmoothDamp(targetWeaponRotation, Vector3.zero, ref targetWeaponRotationVelocity, SwayResetSmoothing);
        newWeaponRotation = Vector3.SmoothDamp(newWeaponRotation, targetWeaponRotation, ref newWeaponRotationVelocity, SwaySmoothing);

        gun.transform.localRotation = Quaternion.Euler(newWeaponRotation);
    }
}
