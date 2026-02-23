using UnityEngine;
using UnityEngine.InputSystem;
using Unity.Cinemachine;

public class CameraSwitch : MonoBehaviour
{
    public InputAction cameraSwitch;
    public CinemachineCamera camera1;
    public CinemachineCamera camera2;

    public PlayerMovement player;
    public VehicleMovement vehicle;

    private void Update()
    {
        if (Keyboard.current.digit1Key.wasPressedThisFrame) // player camera
        {
            CameraManager.SwitchCamera(camera1);
            player.enabled = true;
            vehicle.enabled = false;
        }

        else if (Keyboard.current.digit2Key.wasPressedThisFrame) // vehicle camera
        {
            CameraManager.SwitchCamera(camera2);
            player.enabled = false;
            vehicle.enabled = true;
        }
    }
}
