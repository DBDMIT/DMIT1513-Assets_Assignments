using UnityEngine;

public class ObjectSpin : MonoBehaviour
{
    public Vector3 rotation;

    private void Update()
    {
        this.transform.Rotate(rotation * 1 * Time.deltaTime);
    }
}
