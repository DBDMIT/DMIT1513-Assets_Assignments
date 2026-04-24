using UnityEngine;
using UnityEngine.InputSystem;

public class MenuParallax : MonoBehaviour
{
    public float offsetMultiplier = 1f;
    public float smoothTime = 0.3f;

    private Vector3 startPosition;
    private Vector3 velocity;
    private Camera mainCamera;

    void Start()
    {
        startPosition = transform.position;
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (mainCamera == null) return;

        Vector3 offset = mainCamera.ScreenToViewportPoint(Mouse.current.position.ReadValue());
        transform.position = Vector3.SmoothDamp(transform.position, startPosition + (offset * offsetMultiplier), ref velocity, smoothTime);
    }
}
