using System;
using UnityEngine;
[RequireComponent (typeof(Rigidbody))]
[RequireComponent(typeof(AudioSource))]

public class projectile : MonoBehaviour
{
    public float projectileForce;
    private float projectileDamage;
    private Rigidbody rb;
    public AudioClip onHitSfx;
    public event Action<Vector3> OnHit;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        ApplyProjectileForce();
    }

    public void SetProjectileDamage(float damage)
    {
        projectileDamage = damage;
    }

    public void ApplyProjectileForce()
    {
        rb.AddForce(transform.forward * projectileForce, ForceMode.Force);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Rigidbody>() != null) return;
        if (collision.gameObject.GetComponent<idamagable>() == null) return;
        collision.gameObject.GetComponent<idamagable>().TakeDamage(projectileDamage);
        GetComponent<AudioSource>().PlayOneShot(onHitSfx);
        OnHit?.Invoke(transform.position);
    }
}
