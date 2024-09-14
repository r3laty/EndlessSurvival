using System;
using UnityEngine;

public class TankAttack : MonoBehaviour, IDamageable
{
    [SerializeField] private float attackRange;
    [SerializeField] private LayerMask layer;
    [SerializeField] private Transform attackPoint;

    private bool _isReadyToAttack = false;
    private int _damage;

    public int Damage { get; set; }

    private void Start()
    {
        _damage = Damage;
    }
    public void Attack()
    {
        Vector3 origin = attackPoint.position;

        Vector3 direction = attackPoint.forward;

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
