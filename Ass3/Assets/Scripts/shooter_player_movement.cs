using UnityEngine;
using UnityEngine.InputSystem;

public class shooter_player_movement : MonoBehaviour
{
    public InputAction movementInput;
    public InputAction jumpInput;
    public camera_controller cameraController;

    private Vector2 moveVector;
    private Rigidbody rb;
    private Animator animator;

    private GameObject groundReference;
    public bool isGrounded;
    private float groundCheckDistance = 0.2f;

    public float movementSpeed;
    public float jumpForce;

    private void Awake()
    {
        movementInput.Enable();
        movementInput.performed += ReadMoveInput;
        movementInput.canceled += ReadMoveInput;

        jumpInput.Enable();
        jumpInput.performed += Jump;

        groundReference = transform.Find("ground_check").gameObject;

        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        GrounCheck();

        Vector3 moveDirection = (transform.forward * moveVector.y) + (transform.right * moveVector.x);
        Vector3 deltaMovement = moveDirection * movementSpeed * Time.deltaTime;
        rb.Move(transform.position + deltaMovement, transform.rotation);
    }

    private void ReadMoveInput(InputAction.CallbackContext context)
    {
        moveVector = context.ReadValue<Vector2>();
        if (cameraController.currentState == CameraState.THIRD_PERSON)
        {
            animator.SetBool("isWalking", moveVector.y > 0);
            animator.SetBool("isWalkingBack", moveVector.y < 0);
        }
    }

    private void Jump(InputAction.CallbackContext context)
    {
        if (isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    private void GrounCheck()
    {
        if (groundReference != null)
        {
            isGrounded = Physics.Raycast(groundReference.transform.position, Vector3.down, groundCheckDistance);
        }
    }
}

