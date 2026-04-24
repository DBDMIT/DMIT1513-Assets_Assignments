using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class player_movement : MonoBehaviour
{
    public InputAction movementInput;
    public InputAction attackInput;

    private Vector2 moveVector;
    private Rigidbody rb;

    public float movementSpeed;
    public float attackTime;

    private float timestamp;
    player_weapon playerWeapon;

    public UnityEvent OnAttack;

    private void Awake()
    {
        playerWeapon = GetComponent<player_weapon>();

        movementInput.Enable();
        movementInput.performed += ReadMoveInput;
        movementInput.canceled += ReadMoveInput;

        attackInput.Enable();
        attackInput.performed += Attack;

        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Vector3 moveDirection = (transform.forward * moveVector.y) + (transform.right * moveVector.x);

        rb.linearVelocity = new Vector3(moveDirection.x * movementSpeed, rb.linearVelocity.y, moveDirection.z * movementSpeed);
    }

    private void ReadMoveInput(InputAction.CallbackContext context)
    {
        moveVector = context.ReadValue<Vector2>();
    }

    private void Attack(InputAction.CallbackContext context)
    {
        Debug.Log("Attack here");
        OnAttack?.Invoke();
    }
}

