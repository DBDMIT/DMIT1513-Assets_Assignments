using UnityEngine;
using UnityEngine.Events;

public class CollisionEventHandler : MonoBehaviour
{
    public string tagTocheck;
    public UnityEvent OnCollision;

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag(tagTocheck)) return;
        OnCollision?.Invoke();
    }
}
