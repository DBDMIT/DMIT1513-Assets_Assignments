using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;

public class PlayerWeapon : MonoBehaviour
{
    public float damageAmount;

    public Transform anchorPoint;
    public Camera cam;
    public float orbitRadius = 3f;
    public float rotationSpeed = 10f;

    private float currentAngle;

    private void Start()
    {
        if (cam == null)
            cam = Camera.main;

        Vector3 offset = transform.position - anchorPoint.position;
        offset.y = 0f;

        if (offset.sqrMagnitude > 0.001f)
        {
            currentAngle = Mathf.Atan2(offset.x, offset.z) * Mathf.Rad2Deg;
        }
    }

    private void Update()
    {
        RotateWeapon();
    }

    public void RotateWeapon()
    {
        if (anchorPoint == null || cam == null)
            return;

        Ray ray = cam.ScreenPointToRay(Mouse.current.position.ReadValue());
        Plane plane = new Plane(Vector3.up, anchorPoint.position);

        if (plane.Raycast(ray, out float distance))
        {
            Vector3 hitPoint = ray.GetPoint(distance);

            Vector3 direction = hitPoint - anchorPoint.position;
            direction.y = 0f;

            if (direction.sqrMagnitude < 0.001f)
                return;

            direction.Normalize();

            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;

            currentAngle = Mathf.LerpAngle(
                currentAngle,
                targetAngle,
                rotationSpeed * Time.deltaTime
            );

            float rad = currentAngle * Mathf.Deg2Rad;

            Vector3 orbitOffset = new Vector3(
                Mathf.Sin(rad),
                0f,
                Mathf.Cos(rad)
            ) * orbitRadius;

            transform.position = anchorPoint.position + orbitOffset;

            Vector3 lookDir = anchorPoint.position - transform.position;
            lookDir.y = 0f;

            if (lookDir.sqrMagnitude > 0.001f)
            {
                transform.rotation = Quaternion.LookRotation(lookDir);
            }
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision != null && collision.gameObject.tag == "Enemy")
        {
            if (collision.gameObject.GetComponent<IDamagable>() != null)
            {
                SoundManager.Instance.PlaySound3D("PlayerAttack", transform.position);
                collision.gameObject.GetComponent<IDamagable>().TakeDamage(damageAmount);
            }
        }
    }
}
