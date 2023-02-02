using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.XR.Interaction.Toolkit;

public class Shooting : MonoBehaviour
{
    public GunData stats;

    public GameObject[] barrelPoint;
    public GameObject muzzleFlash;
    public GameObject breakParticles;
    public GameObject damageText;

    float bulletCount;
    bool isReloading;

    private void Start()
    {
        XRGrabInteractable grabbable = GetComponent<XRGrabInteractable>();

        grabbable.interactionManager = GameObject.Find("XR Origin").GetComponent<XRInteractionManager>();
        grabbable.activated.AddListener(ShootingBullet);
        grabbable.deactivated.AddListener(StopAutoShooting);
        grabbable.selectExited.AddListener(DropGun);

        bulletCount = stats.maxBullets;
        isReloading = false;
    }
    public void ShootingBullet(ActivateEventArgs arg)
    {
        if (bulletCount > 0) //Can Shoot
        {
            if (stats.isAuto) //Automatic Shooting
            {
                InvokeRepeating("Shoot", 0, stats.attackSpeed);
            }
            if (!stats.isAuto) //Manual Shooting
            {
                Shoot();
            }
        }
        else //Cant Shoot
        {
            if (!isReloading) //Reload Instead
            {
                StartCoroutine(Reloading());
            }
        }
    }

    IEnumerator Reloading()
    {
        isReloading = true;
        //Audio
        //Animation
        yield return new WaitForSeconds(stats.reloadSpeed);
        bulletCount = stats.maxBullets;
        isReloading = false;
    }

    IEnumerator AutoShoot()
    {
        Shoot();
        yield return new WaitForSeconds(stats.attackSpeed);
    }

    public void Shoot()
    {
        for (int x = 0; x < barrelPoint.Length; x++) //Find All Barrel Points
        {
            if (stats.isHitscan)
            {
                RaycastShoot(x);
            }

            if (!stats.isHitscan)
            {
                BulletPhysicsShoot(x);
            }
        }
        bulletCount--; //Minus a Bullet

        //AutoShooter Check
        if (bulletCount <= 0)
        {
            CancelInvoke();
            if (!isReloading) //Reload Instead
            {
                StartCoroutine(Reloading());
            }
        }
    }

    public void StopAutoShooting(DeactivateEventArgs arg)
    {
        CancelInvoke();
    }
    public void DropGun(SelectExitEventArgs arg)
    {
        CancelInvoke();
    }

    public void RaycastShoot(int x)
    {
        //Muzzle Flash
        GameObject mFlash = Instantiate(muzzleFlash, barrelPoint[x].transform.position, transform.rotation);
        Destroy(mFlash, 1);

        RaycastHit hit;
        if(Physics.Raycast(barrelPoint[x].transform.position, -transform.forward, out hit, stats.bulletRange))
        {

            //Hit an Enemy
            if(hit.transform.gameObject.layer == 12)
            {
                EnemyHealth eHealth = hit.transform.GetComponent<EnemyHealth>();
                eHealth.TakeDamage(stats.damage);
                DamageText.DisplayDamageText(stats.damage, damageText, hit.point);
            }

            BreakParticles(hit.point, Quaternion.LookRotation(hit.normal));
        }
    }

    public void BulletPhysicsShoot(int x)
    {
        GameObject cBullet = Instantiate(stats.bulletPrefab, barrelPoint[x].transform.position, Quaternion.identity);
        cBullet.GetComponent<Rigidbody>().velocity = -transform.forward * stats.bulletSpeed;
        cBullet.GetComponent<Bullet>().damage = stats.damage;
        Destroy(cBullet, stats.bulletRange);

        GameObject mFlash = Instantiate(muzzleFlash, barrelPoint[x].transform.position, transform.rotation);
        Destroy(mFlash, 1);
    }

    public void BreakParticles(Vector3 spawnPos, Quaternion lookRot)
    {
        GameObject bp = Instantiate(breakParticles, spawnPos, lookRot);
        Destroy(bp, 1.5f);
    }
}