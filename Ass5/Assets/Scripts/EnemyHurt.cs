using UnityEngine;

public class EnemyHurt : MonoBehaviour
{
    public float damageAmount;

    public void OnCollisionEnter(Collision collision)
    {
        if (collision != null && collision.gameObject.tag == "Enemy")
        {
            if (collision.gameObject.GetComponent<IDamagable>() != null)
            {
                collision.gameObject.GetComponent<IDamagable>().TakeDamage(damageAmount);
            }
        }
    }
}
