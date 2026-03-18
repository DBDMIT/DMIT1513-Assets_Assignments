using UnityEngine;
using UnityEngine.Events;

public class enemy : MonoBehaviour, idamagable
{
    public float hp = 1.0f;
    public UnityEvent OnDeath;

    public void TakeDamage(float damage)
    {
        hp -= damage;

        if(hp <= 0)
        {
            OnDeath?.Invoke();
        }
    }
}
