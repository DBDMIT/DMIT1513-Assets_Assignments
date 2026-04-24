using UnityEngine;
using UnityEngine.Events;
using static UnityEngine.GraphicsBuffer;

public class Enemy : MonoBehaviour, IDamagable
{
    private bool dead;

    [SerializeField] GameObject target;
    [SerializeField] Healthbar healthbar;

    public UIGameInfo uiGameInfo;

    private bool alreadyFound;

    public float damageAmount;

    public float health, maxHealth = 1.0f;
    public UnityEvent OnDeath;

    UnityEngine.AI.NavMeshAgent agent;

    private void Awake()
    {
        healthbar = GetComponentInChildren<Healthbar>();
        uiGameInfo = FindFirstObjectByType<UIGameInfo>();

        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.updateRotation = false;

        dead = false;
    }

    private void Start()
    {
        target = GameObject.FindWithTag("Player");
        alreadyFound = false;

        healthbar.UpdateHealthBar(health, maxHealth);
    }

    public void Update()
    {
        if (target != null)
        {
            agent.destination = target.transform.position;
        }
        
        if (!alreadyFound)
        {
            target = GameObject.FindWithTag("Player");
            alreadyFound = true;
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        healthbar.UpdateHealthBar(health, maxHealth);

        if (health <= 0 && !dead)
        {
            dead = true;
            uiGameInfo.DecreaseZombieCount();
            OnDeath?.Invoke();
        }
    }
}
