using UnityEngine;

public class SpinGameObject : MonoBehaviour
{
    public Vector3 rotation;

    private void Update() // TODO: fix. doesn't work with Move(); function!!
    {
        transform.Rotate(rotation * 1 * Time.deltaTime);
    }
}
