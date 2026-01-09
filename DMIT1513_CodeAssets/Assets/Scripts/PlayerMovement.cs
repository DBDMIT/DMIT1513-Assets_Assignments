using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public InputAction movementAction;
    Transform t;
    Vector3 movementVector;
    public float movementSpeed = 1.0f;

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
        var tmp = context.ReadValue<Vector3>(); 
        movementVector = new Vector3(tmp.x, 0, tmp.y);
    }

    private void FixedUpdate()
    {
        // Transform: holds the player position.
        // movementVector: holds the movement direction.

        t.position += movementVector * movementSpeed * Time.deltaTime;
    }
}
