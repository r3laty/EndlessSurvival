using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private GameObject volumeSettingsMenu;
    [SerializeField] private GameObject characterSelectionsMenu;
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject achievementsMenu;
    /// <summary>
    /// Method on button
    /// </summary>
    public void OnPlayButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    /// <summary>
    /// Method on button
    /// </summary>
    public void OnVolumeSettingsButton()
    {
        mainMenu.SetActive(false);
        volumeSettingsMenu.SetActive(true);
    }
    /// <summary>
    /// Method on button
    /// </summary>
    public void OnCharacterSelectionButton()
    {
        mainMenu.SetActive(false);
        characterSelectionsMenu.SetActive(true);
    }
    public void OnLeaveSelectionButton()
    {
        characterSelectionsMenu.SetActive(false);
        mainMenu.SetActive(true);
    }
    /// <summary>
    /// Method on button
    /// </summary>
    public void OnLeaveVolumeSettingsButton()
    {
        volumeSettingsMenu.SetActive(false);
        mainMenu.SetActive(true);
    }
    /// <summary>
    /// Method on button
    /// </summary>
    public void OnAchievementsButton()
    {
        mainMenu.SetActive(false);
        achievementsMenu.SetActive(true);
    }
    /// <summary>
    /// Method on button
    /// </summary>
    public void OnLeaveAchievementsButton()
    {
        achievementsMenu.SetActive(false);
        mainMenu.SetActive(true);
    }
    /// <summary>
    /// Method on button
    /// </summary>
    public void OnLeaveButton()
    {
        Application.Quit();
    }
}
