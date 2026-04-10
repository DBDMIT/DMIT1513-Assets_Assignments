using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine.Events;

public class jumpscare_end : MonoBehaviour
{
    private void Update()
    {
        StartCoroutine(Wait());
    }
    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(1.5f);
        Application.Quit();
    }
}
