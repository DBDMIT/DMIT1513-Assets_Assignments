using UnityEngine;

public class phillip_chase : MonoBehaviour
{
    public GameObject player;
    public float movementSpeed;

    void FixedUpdate()
    {
        transform.LookAt(player.transform);
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, movementSpeed * Time.deltaTime);
    }
}
