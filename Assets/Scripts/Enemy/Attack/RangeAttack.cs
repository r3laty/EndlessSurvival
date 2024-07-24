using UnityEngine;

public class RangeAttack : MonoBehaviour, IDamageable
{

    [SerializeField] private BulletController magicBallPrefab;
    [Space]
    [SerializeField] private float bulletForce;
    [SerializeField] private Transform attackPoint;
    
    private int _damage;

    public int Damage { get; set; }

    private void Start()
    {
        _damage = Damage;
    }
    public void Attack()
    {
        var instanstiatedBullet = Instantiate(magicBallPrefab.gameObject, attackPoint.position, Quaternion.identity);

        instanstiatedBullet.GetComponent<BulletController>().BulletDamage = _damage;
        instanstiatedBullet.GetComponent<Rigidbody>().AddForce(transform.forward * bulletForce * Time.deltaTime);
    }
}
