using UnityEngine;
using UnityEngine.Events;
using static UnityEngine.GraphicsBuffer;

public class Enemy : MonoBehaviour, IDamagable
{
    [SerializeField] GameObject target;
    [SerializeField] Healthbar healthbar;

    public float damageAmount;

    public float health, maxHealth = 1.0f;
    public UnityEvent OnDeath;

    UnityEngine.AI.NavMeshAgent agent;

    private void Awake()
    {
        healthbar = GetComponentInChildren<Healthbar>();

        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.updateRotation = false;
    }

    private void Start()
    {
        target = GameObject.FindWithTag("Player");
        healthbar.UpdateHealthBar(health, maxHealth);
    }

    public void Update()
    {
        agent.destination = target.transform.position;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        healthbar.UpdateHealthBar(health, maxHealth);

        if (health <= 0)
        {
            OnDeath?.Invoke();
        }
    }
}
