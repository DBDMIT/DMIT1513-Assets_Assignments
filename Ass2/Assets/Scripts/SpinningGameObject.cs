using UnityEngine;

public class SpinningGameObject : MonoBehaviour
{
    public Vector3 rotation;

    private void Update()
    {
        this.transform.Rotate(rotation * 1 * Time.deltaTime);
    }
}
