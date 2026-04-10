using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class screen_interaction : MonoBehaviour
{
    public screen_switch screenSwitch;
    public InputAction screenInput;
    interface bool isActive = false;

    private void Start()
    {
        screenInput.Enable();
        screenInput.performed += SwitchCamera;
    }

    public void SwitchCamera(InputAction.CallbackContext c)
    {
        if (isActive)
        {
            screenSwitch.Switch();
        }
    }

    public void ToggleScreenInput()
    {
        isActive = !isActive;
    }
}
