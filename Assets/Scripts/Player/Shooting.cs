using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Shooting : BaseGun
{
    public Rigidbody CurrentBulletRb {get; set;}
    [SerializeField] private BulletController bulletPrefab;
    [Space]
    [SerializeField] private Transform shotPoint;
    [Space]
    [SerializeField] private float bulletSpeed;
    private void Start()
    {
        _currentBulletCount = bulletsCount;
    }
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
        BulletsCountChanged?.Invoke(_currentBulletCount);
        if (_shootButton)
        {
            Shoot();
            _shootButton = false;
        }

        if (_rechargingButton)
        {
            StartCoroutine(Recharging());
            _rechargingButton = false;
        }
    }
    protected override void Shoot()
    {
        if (!_recharging || _rechargingButton)
        {
            if (!_shootDelay && _currentBulletCount > 0)
            {
                PlayShootSound();

                GameObject instatiatedGameObject = Instantiate(bulletPrefab.gameObject, shotPoint.position, Quaternion.identity);

                BulletController instatiatedBullet = instatiatedGameObject.GetComponent<BulletController>();
                instatiatedBullet.BulletDamage = bulletDamage;

                Rigidbody instatiatedRb = instatiatedGameObject.GetComponent<Rigidbody>();
                instatiatedRb.AddForce(transform.forward * bulletSpeed * Time.deltaTime);

                CurrentBulletRb = instatiatedRb;

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