using UnityEngine;

public class ShowGizmo : MonoBehaviour
{
    [SerializeField] private Color gizmoColour = Color.red;
    [SerializeField] private float radius = 0.5f;
    void OnDrawGizmos()
    {
        Gizmos.color = gizmoColour;
        Gizmos.DrawSphere(transform.position, radius);
    }
}
