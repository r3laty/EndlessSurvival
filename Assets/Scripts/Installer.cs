using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Installer : MonoInstaller
{
    //[SerializeField] private HealthController playerHealth;
    //[SerializeField] private Movement playerMove;
    //[SerializeField] private Shooting playerShoot;
    //[SerializeField] private Transform playerTransform;
    //[SerializeField] private ItemPickUpper itemPick;

    [SerializeField] private List<GameObject> characters = new List<GameObject>();

    [SerializeField] private WaveSpawner waveSpawner;

    [SerializeField] private CharacterLoader characterLoader;

    private int _selectedCharacterIndex;
    private void Start()
    {
        _selectedCharacterIndex = PlayerPrefs.GetInt("SelectedCharacter", 0);
    }
    public override void InstallBindings()
    {
        var currentCharacter = characters[_selectedCharacterIndex];

        Container.Bind<HealthController>().FromInstance(currentCharacter.GetComponent<HealthController>()).AsSingle();
        Container.Bind<Movement>().FromInstance(currentCharacter.GetComponent<Movement>()).AsSingle();
        Container.Bind<Shooting>().FromInstance(currentCharacter.GetComponent<Shooting>()).AsSingle();
        Container.Bind<Transform>().FromInstance(currentCharacter.GetComponent<Transform>()).AsSingle();
        Container.Bind<ItemPickUpper>().FromInstance(currentCharacter.GetComponent<ItemPickUpper>()).AsSingle();
        
        Container.Bind<WaveSpawner>().FromInstance(waveSpawner).AsSingle();
        Container.Bind<CharacterLoader>().FromInstance(characterLoader).AsSingle();
    }
}