using UnityEngine;
using UnityEngine.SceneManagement;

public class UIButtons : MonoBehaviour
{
    public void GoToMenu()
    {
        Debug.Log("Transition to main menu scene");
        SceneManager.LoadScene(0);
    }

    public void GoToSelect()
    {
        Debug.Log("Transition to select scene");
        SceneManager.LoadScene(1);
    }

    public void GoToGame()
    {
        Debug.Log("Transition to game scene");
        SceneManager.LoadScene(2);
    }

    public void Quit()
    {
        Debug.Log("Game quits here");
        Application.Quit();
    }
}
