using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Shooting : MonoBehaviour
{
    [SerializeField] private UnityEvent<int> BulletsCountChanged = new UnityEvent<int>();
    [Space]
    [SerializeField] private BulletController bulletPrefab;
    [Space]
    [SerializeField] private Transform shotPoint;
    [Space]
    [SerializeField] private float delayBetweenShots;
    [SerializeField] private float rechargingTime;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private int bulletsCount;
    [SerializeField] private int bulletDamage;

    private bool _shootButton;
    private bool _rechargingButton;

    private bool _shootDelay;
    private bool _recharging;

    private int _initialDamage;
    private void Start()
    {
        _initialDamage = bulletDamage;
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
        BulletsCountChanged?.Invoke(bulletsCount);

        if (_shootButton)
        {
            Shoot();
            _shootButton = false;
        }

        if (_rechargingButton)
        {
            bulletsCount = 0;
            StartCoroutine(Recharging());
        }
    }
    private void Shoot()
    {
        if (!_recharging || _rechargingButton)
        {
            if (!_shootDelay && bulletsCount > 0)
            {
                GameObject bullet = Instantiate(bulletPrefab.gameObject, shotPoint.position, Quaternion.identity);

                bullet.GetComponent<BulletController>().BulletDamage = bulletDamage;
                bullet.GetComponent<Rigidbody>().AddForce(transform.forward * bulletSpeed * Time.deltaTime);

                bulletsCount--;

                StartCoroutine(DelayBetweenShots());
            }
            else if (bulletsCount <= 0)
            {
                StartCoroutine(Recharging());
            }
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
        bulletsCount = 0;
        _recharging = true;
        yield return new WaitForSeconds(rechargingTime);

        bulletsCount = 10;
        _recharging = false;
    }

    public IEnumerator IncreaseDamage(float timeOfBoost, int damageToBoost)
    {
        bulletDamage += damageToBoost;

        yield return new WaitForSeconds(timeOfBoost);

        bulletDamage = _initialDamage;
    }
}