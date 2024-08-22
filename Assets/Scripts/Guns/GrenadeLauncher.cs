using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeLauncher : BaseGun
{
    [SerializeField] private GameObject grenadePrefab;
    [SerializeField] private float fireRate = 1f;  // Скорость стрельбы
    [SerializeField] private float launchForce = 700f;  // Сила выстрела
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
        if (!_recharging || _rechargingButton)
        {
            if (!_shootDelay && _currentBulletCount > 0)
            {
                PlayShootSound();

                GameObject grenade = Instantiate(grenadePrefab, transform.position, transform.rotation);
                Rigidbody rb = grenade.GetComponent<Rigidbody>();
                rb.AddForce(transform.forward * launchForce);
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
