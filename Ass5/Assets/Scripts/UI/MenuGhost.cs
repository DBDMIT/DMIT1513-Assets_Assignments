using UnityEngine;
using UnityEngine.InputSystem;

public class MenuGhost : MonoBehaviour
{
    public float offsetMultiplier = 1f;
    public float smoothTime = 0.3f;
    public float sineAmplitude = 2f;
    public float sineSpeed = 2f;

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

        float sineOffset = Mathf.Sin(Time.time * sineSpeed) * sineAmplitude;
        Vector3 targetPosition = startPosition + (offset * offsetMultiplier) + Vector3.up * sineOffset;

        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}
