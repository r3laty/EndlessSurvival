using UnityEngine;

public class CharacterLoader : MonoBehaviour
{
    public Transform CurrentTransform => _currentTransform;

    [SerializeField] private GameObject[] characters;

    private Transform _currentTransform;
    private void Start()
    {
        int selectedCharacterIndex = PlayerPrefs.GetInt("SelectedCharacter", 0);
        characters[selectedCharacterIndex].SetActive(true);
        characters[selectedCharacterIndex].tag = TagManager.PlayerTag;

        _currentTransform = characters[selectedCharacterIndex].transform;
    }
}
