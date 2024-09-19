using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

public class PauseForCharacter : MonoBehaviour, IPauseable
{
    [Inject] private Movement _movement;
    [Inject] private BaseGun _baseGun;
    [Inject] private HealthController _health;
    private PlayerInput _playerInput;
    private Rigidbody _playerRigidbody;
    [Inject] private PauseData _pauseData;
    private void Start()
    {
        _playerInput = _movement.GetComponent<PlayerInput>();
        _playerRigidbody = _movement.GetComponent<Rigidbody>();

        _pauseData.Pauseables.Add(this);
        Debug.Log($"Added self to pauseables. New count: {_pauseData.Pauseables.Count}");
    }
    public void GamePause()
    {
        _playerRigidbody.isKinematic = true;
        _playerInput.enabled = false;
        _movement.enabled = false;
        _health.enabled = false;
        if (_baseGun.CurrentBulletRb != null)
        {
            _baseGun.CurrentBulletRb.isKinematic = true;
        }

        if (_baseGun is GrenadeLauncher grenadeLauncher && grenadeLauncher.CurrentGrenade != null)
        {
            grenadeLauncher.CurrentGrenade.enabled = false;
        }

        _baseGun.enabled = false;
    }

    public void GameReset()
    {
        _playerRigidbody.isKinematic = false;
        _playerInput.enabled = true;
        _movement.enabled = true;
        _health.enabled = true;
        if (_baseGun.CurrentBulletRb != null)
        {
            _baseGun.CurrentBulletRb.isKinematic = false;
        }

        if (_baseGun is GrenadeLauncher grenadeLauncher && grenadeLauncher.CurrentGrenade != null)
        {
            grenadeLauncher.CurrentGrenade.enabled = true;
        }

        _baseGun.enabled = true;
    }
}
