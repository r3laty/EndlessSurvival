using System.Collections;
using UnityEngine;

public class PauseController : MonoBehaviour
{
    [SerializeField] private Canvas pauseMenu;

    private bool _pauseButton;
    private bool _isPaused;
    public void SetPauseButton(bool pauseButton)
    {
        _pauseButton = pauseButton;

        if (_pauseButton)
        {
            TogglePause();
        }
    }
    private void TogglePause()
    {
        if (_isPaused)
        {
            ResumeGame();
        }
        else  
        {
            PauseGame();
        }
    }
    private void PauseGame()
    {
        Time.timeScale = 0;
        pauseMenu.gameObject.SetActive(true);
        _isPaused = true;
    }
    private void ResumeGame()
    {
        Time.timeScale = 1;
        pauseMenu.gameObject.SetActive(false);
        _isPaused = false;
    }
}
