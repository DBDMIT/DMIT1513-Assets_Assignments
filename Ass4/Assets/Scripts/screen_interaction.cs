using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.Events;


public class screen_interaction : MonoBehaviour
{
    public screen_switch screenSwitch;
    public InputAction screenInput;
    public UnityEvent onSwitch;
    internal bool isActive = false;

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
            onSwitch?.Invoke();
        }
    }

    public void ToggleScreenInput()
    {
        isActive = !isActive;
    }
}
