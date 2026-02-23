using UnityEngine;
using UnityEngine.Events;

public class CollisionEventHandler : MonoBehaviour
{
    public string tagTocheck;
    public CoinManager coinManager;
    public UnityEvent OnTrigger;
    public UnityEvent OnCollision;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag(tagTocheck)) return;
        OnTrigger?.Invoke();
    }
}
