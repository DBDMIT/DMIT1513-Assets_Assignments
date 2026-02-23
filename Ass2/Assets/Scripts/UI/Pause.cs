using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    public static bool paused = false;
    public GameObject pauseUI;

    public void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            if (paused)
            {
                Resume();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void Resume()
    {
        pauseUI.SetActive(false);
        Time.timeScale = 1.0f;
        paused = false;
    }

    public void PauseGame()
    {
        pauseUI.SetActive(true);
        Time.timeScale = 0.0f;
        paused = true;
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
