using UnityEngine;

public class EnemyHurt : MonoBehaviour
{
    public float damageAmount;

    public void OnTriggerEnter(Collider other)
    {
        if (other != null && other.gameObject.tag == "Player")
        {
            if (other.gameObject.GetComponent<IDamagable>() != null)
            {
                other.gameObject.GetComponent<IDamagable>().TakeDamage(damageAmount);
            }
        }
    }
}
