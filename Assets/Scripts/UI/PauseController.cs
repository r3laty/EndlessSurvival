using UnityEngine;
using Zenject;

public class PauseController : MonoBehaviour
{
    [SerializeField] private Canvas pauseMenu;
    [Space]
    [SerializeField] private GameObject volumeControlMenu;

    private GameOverController _gameOverController;

    private bool _pauseButton;
    private bool _isPaused;
    private void Awake()
    {
        _gameOverController = GetComponent<GameOverController>();
    }
    #region Pause
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
        volumeControlMenu.gameObject.SetActive(false);
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
    #endregion
    /// <summary>
    /// Method on button
    /// </summary>
    public void OnPauseButton()
    {
        PauseGame();
    }

    /// <summary>
    /// Method on button
    /// </summary>
    public void OnContinueButton()
    {
        ResumeGame();
    }

    /// <summary>
    /// Method on button
    /// </summary>
    public void OnTryAgainButton()
    {
        _gameOverController.ResetAll();
    }

    /// <summary>
    /// Method on button
    /// </summary>
    public void OnLeaveButton()
    {
        
    }

    /// <summary>
    /// Method on button
    /// </summary>
    public void OnVolumeControlButton()
    {
        volumeControlMenu.gameObject.SetActive(true);
    }
}
