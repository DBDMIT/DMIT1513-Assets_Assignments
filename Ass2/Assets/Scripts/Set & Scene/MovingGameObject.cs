using UnityEngine;

public class MovingGameObject : MonoBehaviour
{
    public Vector3 maxMoveRange;
    public Vector3 startingPosition;
    public float moveSpeed;
    private Vector3 moveDirection = Vector3.right;
    public Rigidbody rb;

    public void Start()
    {
        startingPosition = transform.position;
        moveDirection = maxMoveRange.normalized;

        rb = GetComponent<Rigidbody>();
    }

    public void Update()
    {
        Vector3 nextPosition = transform.position + moveDirection * moveSpeed * Time.deltaTime;
        Vector3 offset = nextPosition - startingPosition;

        if (Mathf.Abs(offset.x) > maxMoveRange.x ||
            Mathf.Abs(offset.y) > maxMoveRange.y ||
            Mathf.Abs(offset.z) > maxMoveRange.z)
        {
            moveDirection *= -1;
            nextPosition = transform.position + moveDirection * moveSpeed * Time.deltaTime;
        }

        if (rb != null)
        {
            rb.MovePosition(nextPosition);
        }
        else
        {
            transform.position = nextPosition;
        }
    }
}
