using UnityEngine;

public class MovingGameObject : MonoBehaviour
{
    public Vector3 maxMoveRange;
    public Vector3 startingPosition;
    public float moveSpeed;
    private Vector3 moveDirection = Vector3.right;

    public void Start()
    {
        startingPosition = transform.position;
        moveDirection = maxMoveRange.normalized;
    }

    public void Update()
    {
        Vector3 nextPosition = transform.position + moveDirection * moveSpeed * Time.deltaTime;
        Vector3 offset = nextPosition - transform.position;

        if (Mathf.Abs(offset.x) > maxMoveRange.x || // .Abs gives you the scale of the number, not the value (-10 becomes just 10).
            Mathf.Abs(offset.x) > maxMoveRange.y ||
            Mathf.Abs(offset.x) > maxMoveRange.z) 
        {
            moveDirection *= -1;
        }

        transform.position = nextPosition;
    }
}
