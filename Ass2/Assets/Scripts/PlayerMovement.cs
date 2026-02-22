using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public CinemachineOrbitalFollow cameraOrbit;
    public InputAction movementAction;

    Transform t;
    public Vector3 movementVector;

    public float moveSpeed;

    private void Start()
    {
        movementVector = Vector3.zero;
        moveSpeed = 5.0f;

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
        Vector3 v = GetComponent<Rigidbody>().linearVelocity;

        Vector3 rotatedMovement = transform.TransformDirection(movementVector);

        v.x = rotatedMovement.x * moveSpeed;
        v.z = rotatedMovement.z * moveSpeed;
        GetComponent<Rigidbody>().linearVelocity = v;

        transform.rotation = Quaternion.Euler(0, cameraOrbit.HorizontalAxis.Value, 0);
    }
}
