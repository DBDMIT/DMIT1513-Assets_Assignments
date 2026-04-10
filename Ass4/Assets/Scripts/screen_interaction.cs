using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class screen_interaction : MonoBehaviour
{
    public InputAction screenInput;

    private void Start()
    {
        screenInput.Enable();
        screenInput.performed += SwitchCamera;
    }

    public void SwitchCamera(InputAction.CallbackContext c)
    {
        
    }
}
