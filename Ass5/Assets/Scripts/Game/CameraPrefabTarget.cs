using Unity.Cinemachine;
using UnityEngine;

public class CameraPrefabTarget : MonoBehaviour
{
    [SerializeField] GameObject targetObject;
    [SerializeField] CinemachineCamera cinemachineCamera;

    private CharacterSelectSingleton Instance;

    void Awake()
    {
        cinemachineCamera = GetComponent<CinemachineCamera>();

        if (cinemachineCamera == null)
        {
            Debug.Log("This shit dont work");
        }
    }
}
