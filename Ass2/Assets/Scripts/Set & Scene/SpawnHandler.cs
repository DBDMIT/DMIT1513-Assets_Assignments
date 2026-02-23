using UnityEngine;
using UnityEngine.Events;

public class SpawnHandler : MonoBehaviour
{
    public string tagTocheck;
    public Transform spawner;

    public void SpawnPosition()
    {
        if (gameObject.CompareTag(tagTocheck))
        {
            GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
            transform.position = spawner.position;
            transform.rotation = spawner.rotation;
        }
    }
}
