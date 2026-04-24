using UnityEngine;
using UnityEngine.Events;

public class CollisionEventHandler : MonoBehaviour
{
    public string tagTocheck;
    public UnityEvent OnTrigger;
    public UnityEvent OnExt;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag(tagTocheck))
        {
            return;
        }
        OnTrigger?.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.gameObject.CompareTag(tagTocheck))
        {
            return;
        }
        OnExt?.Invoke();
    }
}
