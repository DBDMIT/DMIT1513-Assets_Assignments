using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public CinemachineOrbitalFollow cameraOrbit;
    public InputAction movementAction;
    public Transform playerCamera;

    Transform t;
    public Vector3 movementVector;

    public float moveSpeed = 1.0f;
    public float turnSpeed = 1.0f;


    private void Start()
    {
        movementVector = Vector3.zero;

        t = GetComponent<Transform>();

        movementAction.Enable();
        movementAction.performed += MoveCharacter;
        movementAction.canceled += MoveCharacter;
    }

    private void MoveCharacter(InputAction.CallbackContext context)
    {
        var tmp = context.ReadValue<Vector2>();
        movementVector = new Vector3(tmp.x, 0, tmp.y);
    }

    private void FixedUpdate()
    {
        Turn();

        Vector3 v = GetComponent<Rigidbody>().linearVelocity;

        Vector3 rotatedMovement = transform.TransformDirection(movementVector) * moveSpeed;

        v.x += rotatedMovement.x;
        v.z += rotatedMovement.z;

        GetComponent<Rigidbody>().linearVelocity = v;
    }

    private void Turn()
    {
        Vector3 currentLookDirection = cameraOrbit.transform.forward;
        currentLookDirection.y = 0;

        Quaternion targetRotation = Quaternion.LookRotation(currentLookDirection);
        transform.rotation = targetRotation;
    }
}
