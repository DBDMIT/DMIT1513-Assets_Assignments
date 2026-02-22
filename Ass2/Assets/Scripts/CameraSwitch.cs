using UnityEngine;
using UnityEngine.InputSystem;
using Unity.Cinemachine;

public class CameraSwitch : MonoBehaviour
{
    public InputAction cameraSwitch;
    public CinemachineCamera camera1;
    public CinemachineCamera camera2;

    private void Update()
    {
        if (Keyboard.current.digit1Key.wasPressedThisFrame) // player camera
        {
            CameraManager.SwitchCamera(camera1);
        }

        else if (Keyboard.current.digit2Key.wasPressedThisFrame) // vehicle camera
        {
            CameraManager.SwitchCamera(camera2);
        }
    }
}
