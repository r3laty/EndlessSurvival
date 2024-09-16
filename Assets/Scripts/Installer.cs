using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Installer : MonoInstaller
{
    [Header("Characters")]
    [SerializeField] private List<GameObject> characters = new List<GameObject>();
    [SerializeField] private CharacterLoader characterLoader;
    [Header("Enemies"), Space]
    [SerializeField] private WaveSpawner waveSpawner;
    [Header("Pause"), Space]
    [SerializeField] private PauseController pauseController;

    private int _selectedCharacterIndex;
    public override void InstallBindings()
    {
        _selectedCharacterIndex = PlayerPrefs.GetInt("SelectedCharacter", 0);


        var currentCharacter = characters[_selectedCharacterIndex];

        Container.Bind<HealthController>().FromInstance(currentCharacter.GetComponent<HealthController>()).AsSingle();
        Container.Bind<Movement>().FromInstance(currentCharacter.GetComponent<Movement>()).AsSingle();

        Container.Bind<BaseGun>().FromInstance(currentCharacter.GetComponent<BaseGun>()).AsSingle();

        Container.Bind<Transform>().FromInstance(currentCharacter.GetComponent<Transform>()).AsSingle();
        Container.Bind<ItemPickUpper>().FromInstance(currentCharacter.GetComponent<ItemPickUpper>()).AsSingle();

        Container.Bind<WaveSpawner>().FromInstance(waveSpawner).AsSingle();

        Container.Bind<CharacterLoader>().FromInstance(characterLoader).AsSingle();

        Container.Bind<PauseData>().FromNew().AsCached();
    }
}