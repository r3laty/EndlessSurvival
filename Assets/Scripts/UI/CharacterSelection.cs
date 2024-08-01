using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelection : MonoBehaviour
{
    /// <summary>
    /// Selection method
    /// </summary>
    /// <param name="characterIndex">index of character. The ranged from 0 to 2</param>
    public void SelectCharacter(int characterIndex)
    {
        PlayerPrefs.SetInt("SelectedCharacter", characterIndex);
        SceneManager.LoadScene(1);
    }
}
