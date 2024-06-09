using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    //this camera was removed from scene since it wont work with prefabs
    //public Camera playerCamera;

    //Shooting
    public bool isShooting, readyToShoot;
    public bool allowReset = true;
    public float shootingDelay = 2f;

    //Burst
    public int bulletsPerBurst = 3;
    public int burstBulletsLeft;

    //Spread
    public float spreadIntensity;

    //Bullet Properties
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public float bulletVelocity = 30f;
    public float bulletPrefabLifeTime = 3f;

    public enum ShootingMode
    {
        Single,
        Burst,
        Auto
    }

    public ShootingMode currentShootingMode;

    private void Awake()
    {
        readyToShoot = true;
        burstBulletsLeft = bulletsPerBurst;
    }

    // Update is called once per frame
    void Update()
    {
        if ( currentShootingMode == ShootingMode.Auto)
        {
            //Holding the Down Left Mouse Button
            isShooting = Input.GetKey(KeyCode.Mouse0);
        }
        else if ( currentShootingMode == ShootingMode.Burst || currentShootingMode == ShootingMode.Single)
        {
            //Clicking Down Left Mouse Button
            isShooting = Input.GetKeyDown(KeyCode.Mouse0);
        }
        if ( readyToShoot && isShooting )
        {
            burstBulletsLeft = bulletsPerBurst;
            FireWeapon();
        }
    }

    private void FireWeapon()
    {
        readyToShoot = false; //to prevent bullet from shooting twice

        Vector3 shootingDirection = CalculateDirectionAndSpeed().normalized;

        //Instantiate the bullet
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, Quaternion.identity);

        //Pointing the bullet to face the shooting direction
        bullet.transform.forward = shootingDirection;

        //Shoot the bullet
        bullet.GetComponent<Rigidbody>().AddForce(bulletSpawn.forward.normalized * bulletVelocity, ForceMode.Impulse);

        //Destroy the bullet
        StartCoroutine(DestroyBulletAfterTime(bullet, bulletPrefabLifeTime));

        //Checking if we done shooting
        if (allowReset)
        {
            Invoke("ResetShot", shootingDelay);
            allowReset = false;
        }

        //Checking if it is in burst Mode
        if (currentShootingMode == ShootingMode.Burst && burstBulletsLeft > 1)
        {
            burstBulletsLeft--;
            Invoke("FireWeapon", shootingDelay);
        }

    }

    private void ResetShot()
    {
        readyToShoot = true;
        allowReset = true;
    }

    private Vector3 CalculateDirectionAndSpeed()
    {
        //Shooting from middle of screen to check where we are pointing
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f,0));
        RaycastHit hit;

        Vector3 targetPoint;
        if( Physics.Raycast(ray, out hit))
        { 
            //Hitting something
            targetPoint = hit.point;
        }
        else
        {
            //Shooting at the air
            targetPoint = ray.GetPoint(100);
        }

        Vector3 direction = targetPoint - bulletSpawn.position;

        float x = UnityEngine.Random.Range(-spreadIntensity, spreadIntensity);
        float y = UnityEngine.Random.Range(-spreadIntensity, spreadIntensity);

        //Returning the shooting direction and spread
        return direction + new Vector3(x, y, 0);    
    }

    private void StartCoroutine(IEnumerable enumerable)
    {
        //Nothing is in here :)
    }

    private IEnumerable DestroyBulletAfterTime(GameObject bullet, float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(bullet);
    }
}
