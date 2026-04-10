using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class screen_interaction : MonoBehaviour
{
    public InputAction screenInput;
    bool isActive = false;

    private void Start()
    {
        screenInput.Enable();
        screenInput.performed += SwitchCamera;
    }

    public void SwitchCamera(InputAction.CallbackContext c)
    {
        if (isActive)
        {
            Debug.Log("Screen should switch now");
        }
    }

    public void ToggleScreenInput()
    {
        isActive = !isActive;
    }
}
