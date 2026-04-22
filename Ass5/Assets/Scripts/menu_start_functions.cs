using UnityEngine;
using UnityEngine.SceneManagement;

public class menu_start_functions : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
        Debug.Log("Game quits here");
        Application.Quit();
    }
}
