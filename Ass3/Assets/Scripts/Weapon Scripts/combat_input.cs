using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class combat_input : MonoBehaviour
{
    public InputAction shootInput;

    void Start()
    {
        shootInput.Enable();
        shootInput.performed += ShootInputPerformed;
        shootInput.canceled += ShootInputReleased;
    }

    // Update is called once per frame
    private void ShootInputPerformed(InputAction.CallbackContext c)
    {
        GetComponent<gun>().Shoot();
    }

    private void ShootInputReleased(InputAction.CallbackContext c)
    {
        GetComponent<gun>().StopShooting();
    }
}
