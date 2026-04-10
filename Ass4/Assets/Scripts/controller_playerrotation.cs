using UnityEngine;
using UnityEngine.InputSystem;

public class controller_playerrotation : MonoBehaviour
{
    public InputAction rotationInput;
    public float sensitivity = 0.1f;
    private float yaw, pitch;
    public float maxPitch;
    public Transform spineX;
    public Transform spineY;


    private void Start()
    {
        rotationInput.Enable();
        rotationInput.performed += OnLook;
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void OnLook(InputAction.CallbackContext c)
    {
        Vector2 mouseDelta = c.ReadValue<Vector2>();

        yaw += mouseDelta.x * sensitivity;
        pitch -= mouseDelta.y * sensitivity;
    }

    public void Update()
    {
        pitch = Mathf.Clamp(pitch, -maxPitch, maxPitch);

        spineY.localRotation = Quaternion.Euler(pitch, 0, 0);
        spineX.localRotation = Quaternion.Euler(0, yaw, 0);
    }
}
