using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Zenject.Asteroids;

public class Shotgun : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [Space]
    [SerializeField] private float bulletSpeed;
    [SerializeField] private float bulletLifetime = 2f;
    [Space]
    [SerializeField] private Transform shootPoint;
    [Space]
    [SerializeField] private int damage = 10;
    [Space]
    [SerializeField] private int maxAmmo;
    [Space]
    [SerializeField] private float fireRate = 5f;
    [SerializeField] private float reloadTime;
    [Space]
    [SerializeField] private float spreadAngle = 5f;
    [Space]
    [SerializeField] private int bulletsPerShot = 6;
    [Space]
    [SerializeField] private float delayBetweenShots;
    [SerializeField] private float rechargingTime;
    [Space]
    [SerializeField] private EventReference shotSound;

    private int _currentAmmo;
    private bool _recharging;
    private bool _shootDelay;
    private int _initialDamage;
    private bool _rechargingButton;
    private bool _shootButton;

    private void Awake()
    {
        _currentAmmo = maxAmmo;
        _initialDamage = damage;
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
        if (_shootButton)
        {
            Shoot();
            _shootButton = false;
        }

        if (_rechargingButton)
        {
            _currentAmmo = 0;
            StartCoroutine(Recharging());
        }
    }
    private void Shoot()
    {
        Vector3 shootDirection = transform.forward;
        if (!_recharging || _rechargingButton)
        {
            if (!_shootDelay && _currentAmmo > 0)
            {
                PlayShootSound();

                for (int i = 0; i < bulletsPerShot; i++)
                {
                    Vector3 direction = GetSpreadDirection(shootDirection);
                    
                    GameObject bullet = Instantiate(bulletPrefab, shootPoint.position, Quaternion.identity);
                    Rigidbody rb = bullet.GetComponent<Rigidbody>();

                    rb.AddForce(transform.forward * bulletSpeed * Time.deltaTime);

                    Destroy(bullet, bulletLifetime);
                }
                _currentAmmo--;

                StartCoroutine(DelayBetweenShots());
            }
            else if (_currentAmmo <= 0)
            {
                StartCoroutine(Recharging());
            }
        }
    }
    private void PlayShootSound()
    {
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.PlayOneShot(shotSound, this.transform.position);
        }
    }

    private IEnumerator DelayBetweenShots()
    {
        _shootDelay = true;
        yield return new WaitForSeconds(delayBetweenShots);

        _shootDelay = false;
    }
    private IEnumerator Recharging()
    {
        _currentAmmo = 0;
        _recharging = true;
        yield return new WaitForSeconds(rechargingTime);

        _currentAmmo = maxAmmo;
        _recharging = false;
    }
    private Vector3 GetSpreadDirection(Vector3 baseDirection)
    {
        float spreadX = Random.Range(-spreadAngle, spreadAngle);
        float spreadZ = Random.Range(-spreadAngle, spreadAngle);

        Quaternion spreadRotation = Quaternion.Euler(0, spreadX, spreadZ);
        Vector3 direction = spreadRotation * baseDirection;

        return direction;
    }

    public IEnumerator IncreaseDamage(float timeOfBoost, int damageToBoost)
    {
        damage += damageToBoost;

        yield return new WaitForSeconds(timeOfBoost);

        damage = _initialDamage;
    }
}
