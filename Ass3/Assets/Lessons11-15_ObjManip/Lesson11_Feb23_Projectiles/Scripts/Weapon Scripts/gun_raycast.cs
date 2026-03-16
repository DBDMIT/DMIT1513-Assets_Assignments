using System.Collections;
using UnityEngine;

public class gun_raycast : gun
{
    private bool isFiring = false;

    public override void Reload()
    {

    }

    public override void Shoot()
    {
        isFiring = true;

        StartCoroutine(FireCoroutine());
    }

    public override void StopShooting()
    {
        isFiring = false;
    }

    private IEnumerator FireCoroutine()
    {
        while (isFiring)
        {
            RaycastHit hit;
            Physics.Raycast(bulletSpawnLocation.position, bulletSpawnLocation.forward, out hit, Mathf.Infinity);
            GetComponent<AudioSource>().PlayOneShot(fireSfx);
            Debug.DrawRay(bulletSpawnLocation.position, bulletSpawnLocation.forward, Color.red, 3.0f);

            if (hit.collider != null)
            {
               if(hit.collider.GetComponent<idamagable>() != null) hit.collider.gameObject.GetComponent<idamagable>().TakeDamage(dmg);
            }
            yield return new WaitForSeconds(fireRate);
        }

        yield return null;
    }
}
