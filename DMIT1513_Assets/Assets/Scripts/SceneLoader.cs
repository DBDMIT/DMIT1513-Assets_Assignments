using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void Start()
    {
        //LoadScene(1);
    }

    public void LoadScene(int index)
    {
        SceneManager.LoadScene(1);
    }
}
