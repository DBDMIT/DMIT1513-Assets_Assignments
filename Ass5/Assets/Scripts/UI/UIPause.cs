using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class UIPause : MonoBehaviour
{
    public InputAction pauseInput;

    public GameObject pauseMenuUI;
    public GameObject gameUI;

    public static UIPause instance;
    private bool isPaused = false;
    public event Action<bool> OnPauseToggle;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        pauseInput.Enable();
        pauseInput.performed += PauseInputPressed;
    }

    private void PauseInputPressed(InputAction.CallbackContext c)
    {
        if (!isPaused)
        {
            Pause();
            return;
        }

        Resume();
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        gameUI.SetActive(false);
        Time.timeScale = 0.0f;
        isPaused = true;
        //Cursor.lockState = CursorLockMode.None;
        OnPauseToggle?.Invoke(isPaused);
    }

    public void Resume()
    {
        Time.timeScale = 1.0f;
        //Cursor.lockState = CursorLockMode.Locked;

        pauseMenuUI.SetActive(false);
        gameUI.SetActive(true);
        isPaused = false;
        OnPauseToggle?.Invoke(isPaused);
    }

    public void EnableInput()
    {
        pauseInput.Enable();
    }

    public void DisableInput()
    {
        pauseInput.Disable();
    }

    public void ReturnToMenu()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(0);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
