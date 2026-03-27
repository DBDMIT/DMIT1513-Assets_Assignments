using System.Collections;
using UnityEngine;

public class gun_physical : gun
{
    public GameObject projectilePrefab;
    private bool canFire = true;

    public override void Reload()
    {
        throw new System.NotImplementedException();
    }

    public override void Shoot()
    {
        // fire the projectiles
        // set canFire = false
        // start the coroutine

        if (canFire)
        {
            GameObject tmp = Instantiate(projectilePrefab, bulletSpawnLocation.position, Quaternion.identity);
            projectile p = tmp.GetComponent<projectile>();

            p.SetProjectileDamage(dmg);
            p.ApplyProjectileForce();
            p.OnHit += ProjectileHit;

            GetComponent<AudioSource>().PlayOneShot(fireSFX);
            canFire = false;
            StartCoroutine(FireDelay());
        }


    }
    private void ProjectileHit(Vector3 hitLocation)
    {
        Instantiate(hitFX, hitLocation, Quaternion.identity);
    }

    public override void StopShooting()
    {

    }

    private IEnumerator FireDelay()
    {
        yield return new WaitForSeconds(fireRate);
        canFire = true;
    }
}
