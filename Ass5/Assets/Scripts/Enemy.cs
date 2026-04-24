using UnityEngine;
using UnityEngine.Events;
using static UnityEngine.GraphicsBuffer;

public class Enemy : MonoBehaviour, idamagable
{
    [SerializeField] GameObject target;

    public float hp = 1.0f;
    public UnityEvent OnDeath;

    UnityEngine.AI.NavMeshAgent agent;

    private void Awake()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.updateRotation = false;
    }

    private void Start()
    {
        target = GameObject.FindWithTag("Player");
    }

    public void Update()
    {
        agent.destination = target.transform.position;
    }

    public void TakeDamage(float damage)
    {
        hp -= damage;

        if (hp <= 0)
        {
            OnDeath?.Invoke();
        }
    }
}
