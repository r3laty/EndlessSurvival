using UnityEngine;
using Zenject;

public class Installer : MonoInstaller
{
    [SerializeField] private HealthController playerHealth;
    [SerializeField] private Movement playerMove;
    [SerializeField] private Shooting playerShoot;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private WaveSpawner waveSpawner;
    public override void InstallBindings()
    {
        Container.Bind<HealthController>().FromInstance(playerHealth).AsSingle();
        Container.Bind<Movement>().FromInstance(playerMove).AsSingle();
        Container.Bind<Shooting>().FromInstance(playerShoot).AsSingle();
        Container.Bind<Transform>().FromInstance(playerTransform).AsSingle();
        Container.Bind<WaveSpawner>().FromInstance(waveSpawner).AsSingle();
    }
}