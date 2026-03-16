using UnityEngine;
[RequireComponent(typeof(AudioSource))]

public abstract class gun : MonoBehaviour
{
    public int magazineSize;
    public int ammoCount;
    public float fireRate;
    public float dmg;
    public Transform bulletSpawnLocation;
    public AudioClip fireSfx;
    public GameObject hitFX;

    public abstract void Reload();

    public abstract void StopShooting();

    public abstract void Shoot();

}
