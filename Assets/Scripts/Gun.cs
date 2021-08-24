using UnityEngine;
using System.Collections;

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

    void Start()
    {
        currentAmmo = maxAmmo;
    }

    void Update()
    { 

        if (isReloading)
        {
            return;
        }

        if (currentAmmo <= 0)
        {
            StartCoroutine(Reload());
            return;
        }

        if (Input.GetMouseButton(0) && Time.time > nextTimeToFire)
        {
            print("Pew"); // Temp
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

        print("Reloading................");
        yield return new WaitForSeconds(reloadTime);

        currentAmmo = maxAmmo;

        isReloading = false;
    }
}
