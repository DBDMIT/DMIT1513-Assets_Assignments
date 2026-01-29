using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public InputAction movementAction;
    Transform t;
    Vector3 movementVector;
    public float moveSpeed = 1.0f;
    public float facingDirection = 1;

    private void Start()
    {
        movementVector = Vector3.zero;
        movementAction.Enable();
        t = GetComponent<Transform>();
        movementAction.performed += MoveCharacter;
        movementAction.canceled += MoveCharacter;
    }

    private void MoveCharacter(InputAction.CallbackContext context)
    {
        var tmp = context.ReadValue<Vector2>();
        movementVector = new Vector3(tmp.x, 0, tmp.y);
    }

    private void Update()
    {
        Flip();
    }

    private void FixedUpdate()
    {
        t.position += movementVector * moveSpeed * Time.deltaTime;
    }

    void Flip()
    {
        if (movementVector.x > 0.1f)
        {
            facingDirection = 1;
        }
        
        else if (movementVector.x < -0.1f)
        {
            facingDirection = -1;
        }

        transform.localScale = new Vector3(facingDirection * 10, transform.localScale.y, transform.localScale.z);
    }
}
