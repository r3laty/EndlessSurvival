using System.Collections;
using UnityEngine;
using Zenject;

public class PauseController : MonoBehaviour
{
    [SerializeField] private Canvas pauseMenu;
    [Space]
    [SerializeField] private GameObject volumeControlMenu;
    [Space]
    [SerializeField] private float pauseDelay = 0.5f;

    [Inject] private BaseGun _shooting;

    private GameOverController _gameOverController;
    private MonoBehaviour _shootingScript;

    private bool _pauseButton;
    private bool _isPaused;
    private bool _canTogglePause = true;
    private void Awake()
    {
        _gameOverController = GetComponent<GameOverController>();
    }
    #region Pause
    public void SetPauseButton(bool pauseButton)
    {
        _pauseButton = pauseButton;

        if (_pauseButton && _canTogglePause)
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

        StartCoroutine(PauseCooldown());
    }
    private void PauseGame()
    {
        _shooting.enabled = false;
        volumeControlMenu.gameObject.SetActive(false);
        Time.timeScale = 0;
        pauseMenu.gameObject.SetActive(true);
        _isPaused = true;
    }
    private void ResumeGame()
    {
        _shooting.enabled = true;
        Time.timeScale = 1;
        pauseMenu.gameObject.SetActive(false);
        _isPaused = false;
    }
    private IEnumerator PauseCooldown()
    {
        _canTogglePause = false;
        yield return new WaitForSecondsRealtime(pauseDelay);
        _canTogglePause = true;
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
        _gameOverController.OnLeaveButton();
    }

    /// <summary>
    /// Method on button
    /// </summary>
    public void OnVolumeControlButton()
    {
        volumeControlMenu.gameObject.SetActive(true);
    }
}
