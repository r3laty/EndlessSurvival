using UnityEngine;
using Zenject;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private Canvas mainMenu;
    [SerializeField] private Canvas inGameMenu;

    [Inject] private Shooting _shooting;
    private void Start()
    {
        Time.timeScale = 0;
        _shooting.enabled = false;
    }
    /// <summary>
    /// Method on button
    /// </summary>
    public void OnPlayButton()
    {
        mainMenu.gameObject.SetActive(false);
        inGameMenu.gameObject.SetActive(true);
        _shooting.enabled = true;
        Time.timeScale = 1;
    }
    /// <summary>
    /// Method on button
    /// </summary>
    public void OnLeaveButton()
    {
        Application.Quit();
    }
}
