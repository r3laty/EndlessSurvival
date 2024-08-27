using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeLauncher : BaseGun
{
    [SerializeField] private GameObject grenadePrefab;
    [SerializeField] private Transform shotPoint;
    [SerializeField] private float fireRate = 1f;
    [SerializeField] private float launchForce = 700f;
    public void SetShootButton(bool shotButton)
    {
        _shootButton = shotButton;
    }
    public void SetRechargingButton(bool rechargingButton)
    {
        _rechargingButton = rechargingButton;
    }
    private void Update()
    {
        if (_shootButton)
        {
            Shoot();
            _shootButton = false;
        }

        if (_rechargingButton)
        {
            _currentBulletCount = 0;
            StartCoroutine(Recharging());
        }
    }
    protected override void Shoot()
    {
        Debug.Log($"{_shootDelay} shoot delay " +
    $"\n{_currentBulletCount} bullet count" +
    $"\nshoot");

        if (!_recharging || _rechargingButton)
        {
            if (!_shootDelay && _currentBulletCount > 0)
            {
                Debug.Log($"{_shootDelay} shoot delay " +
                    $"\n{_currentBulletCount} bullet count" +
                    $"\nshoot");

                PlayShootSound();

                GameObject grenade = Instantiate(grenadePrefab, shotPoint.position, Quaternion.identity);
                Rigidbody grenadeRb = grenade.GetComponent<Rigidbody>();
                grenadeRb.AddForce(transform.forward * launchForce * Time.deltaTime);
                _currentBulletCount--;

                StartCoroutine(DelayBetweenShots());
            }
            else if (_currentBulletCount <= 0)
            {
                StartCoroutine(Recharging());
            }
        }
    }
}
