using UnityEngine;
using Zenject;
using System.Linq;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    [SerializeField] private GameObject statisticsMenu;
    [SerializeField] private GameObject gameoverMenu;
    
    /// <summary>
    /// Method on button
    /// </summary>
    public void ResetAll()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        Time.timeScale = 1;
    }

    /// <summary>
    /// Method on button
    /// </summary>
    public void OnLeaveButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    /// <summary>
    /// Method on button
    /// </summary>
    public void OnStatsButton()
    {
        statisticsMenu.SetActive(true);
        gameObject.SetActive(false);
    }

    /// <summary>
    /// Method on button
    /// </summary>
    public void OnLeaveStatsButton()
    {
        gameoverMenu.SetActive(true);
        statisticsMenu.SetActive(false);
    }
}
