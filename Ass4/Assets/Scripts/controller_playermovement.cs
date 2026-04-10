using TMPro.Examples;
using UnityEngine;
using UnityEngine.InputSystem;

public class controller_playermovement : MonoBehaviour
{
    public InputAction movementInput;
    private Vector2 moveVector;
    private Rigidbody rb;
    public float movementSpeed;

    private void Awake()
    {
        movementInput.Enable();
        movementInput.performed += ReadMoveInput;
        movementInput.canceled += ReadMoveInput;

        rb = GetComponent<Rigidbody>();
    }

    private void ReadMoveInput(InputAction.CallbackContext context)
    {
        moveVector = context.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        Vector3 moveDirection = (transform.forward * moveVector.y) + (transform.right * moveVector.x);

        Vector3 deltaMovement = moveDirection * movementSpeed * Time.deltaTime;

        rb.Move(transform.position + deltaMovement, transform.rotation);
    }
}
