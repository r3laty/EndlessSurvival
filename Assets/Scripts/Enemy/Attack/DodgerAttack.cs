using UnityEngine;

public class DodgerAttack : MonoBehaviour, IDamageable
{

    [SerializeField] private float attackRange;
    [SerializeField] private LayerMask layer;

    private int _damage;

    public int Damage { get; set; }
    private void Start()
    {
        _damage = Damage;
    }
    public void Attack()
    {
        Vector3 origin = transform.position;

        Vector3 direction = transform.forward;

        if (Physics.Raycast(origin, direction, out RaycastHit hit, attackRange, layer))
        {
            HealthController playerHealth = hit.collider.GetComponent<HealthController>();
            if (playerHealth != null)
            {
                playerHealth.DealDamage(_damage);
            }
        }
        else
        {
            Debug.Log("Hit is miss");
        }
    }
}
