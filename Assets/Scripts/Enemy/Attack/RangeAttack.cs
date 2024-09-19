using UnityEngine;

public class RangeAttack : MonoBehaviour, IDamageable, IPauseable
{

    [SerializeField] private BulletController magicBallPrefab;
    [Space]
    [SerializeField] private float bulletForce;
    [SerializeField] private Transform attackPoint;
    
    private Rigidbody _instanstiatedBulletRb;
    private int _damage;

    public int Damage { get; set; }

    private void Start()
    {
        _damage = Damage;
    }
    public void Attack()
    {
        var instanstiatedBullet = Instantiate(magicBallPrefab.gameObject, attackPoint.position, Quaternion.identity);

        var instanstiatedBulletController = instanstiatedBullet.GetComponent<BulletController>();
        instanstiatedBulletController.BulletDamage = _damage;

        _instanstiatedBulletRb = instanstiatedBullet.GetComponent<Rigidbody>();
        _instanstiatedBulletRb.AddForce(transform.forward * bulletForce * Time.deltaTime);
    }

    public void GamePause()
    {
        _instanstiatedBulletRb.isKinematic = true;
    }

    public void GameReset()
    {
        _instanstiatedBulletRb.isKinematic = true;
    }
}
