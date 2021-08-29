using UnityEngine;
using System.Collections;
using TMPro;

public class Gun : MonoBehaviour
{
    public float damage;
    public float range;
    public float fireRate;
    private float nextTimeToFire = 0f;

    public int maxAmmo;
    private int currentAmmo;
    public float reloadTime;
    private bool isReloading = false;

    public Camera cam;
    public ParticleSystem LaserBeam;
    public ParticleSystem muzzleFlash;
    public Animator weaponAnimator;

    public TMP_Text ammoCounter;

    void Start()
    {
        currentAmmo = maxAmmo;
    }

    void Update()
    {
        ammoCounter.text = currentAmmo.ToString();

        if (isReloading)
        {
            return;
        }

        if (currentAmmo <= 0 || Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(Reload());
            return;
        }

        if (Input.GetMouseButton(0) && Time.time > nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }
    }

    void Shoot()
    {
        RaycastHit hit;

        currentAmmo--;

        muzzleFlash.Play();
        LaserBeam.Play();
        weaponAnimator.SetTrigger("Shoot");
        AudioManager.instance.Play("Laser");

        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
        {
            TakeDamage takeDamage = hit.transform.GetComponent<TakeDamage>();

            if (takeDamage != null)
            {
                takeDamage.DamageHealth(damage);
            }
        }
        
    }

    IEnumerator Reload()
    {
        isReloading = true;
        weaponAnimator.SetTrigger("Reload");

        yield return new WaitForSeconds(reloadTime);

        currentAmmo = maxAmmo;

        isReloading = false;
    }
}
