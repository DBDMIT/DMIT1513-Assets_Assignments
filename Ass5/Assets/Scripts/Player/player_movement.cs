using UnityEngine;
using UnityEngine.InputSystem;

public class player_movement : MonoBehaviour
{
    public InputAction movementInput;
    public InputAction attackInput;

    private Vector2 moveVector;
    private Rigidbody rb;

    public float movementSpeed;
    public float attackTime;

    private void Awake()
    {
        movementInput.Enable();
        movementInput.performed += ReadMoveInput;
        movementInput.canceled += ReadMoveInput;

        attackInput.Enable();
        attackInput.performed += Attack;

        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Vector3 moveDirection = (transform.forward * moveVector.y) + (transform.right * moveVector.x);
        Vector3 deltaMovement = moveDirection * movementSpeed * Time.deltaTime;
        rb.Move(transform.position + deltaMovement, transform.rotation);
    }

    private void ReadMoveInput(InputAction.CallbackContext context)
    {
        moveVector = context.ReadValue<Vector2>();
    }

    private void Attack(InputAction.CallbackContext context)
    {

    }
}

