using System.Collections;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public float BulletDamage;

    [SerializeField] private float explosionRadius = 5f;
    [SerializeField] private float explosionForce = 700f;
    [SerializeField] private float timeToExplode;
    [SerializeField] private ParticleSystem explotionFx;
    [SerializeField] private LayerMask layerMask;
    private MeshRenderer _mesh;
    private CapsuleCollider _collider;
    private void Awake()
    {
        _mesh = GetComponent<MeshRenderer>();
        _collider = GetComponent<CapsuleCollider>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(TagManager.FloorTag))
        {
            Invoke("Explode", timeToExplode);
        }
    }

    private void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius, layerMask);

        foreach (Collider nearbyObject in colliders)
        {
            float distance = Vector3.Distance(transform.position, nearbyObject.transform.position);
            float damage = CalculateDamage(distance);

            if (nearbyObject.TryGetComponent<HealthController>(out HealthController targetHealth))
            {
                targetHealth.DealDamage((int)damage);
            }
        }

        StartCoroutine(DestroyAfterTime());
    }

    private float CalculateDamage(float distance)
    {
        float damage = BulletDamage * (1 - distance / explosionRadius);
        return Mathf.Max(0f, damage);
    }

    private IEnumerator DestroyAfterTime()
    {
        ParticleSystem instantiatedFx = Instantiate(explotionFx, transform.position, Quaternion.identity);

        _mesh.enabled = false;
        _collider.enabled = false;

        yield return new WaitForSeconds(instantiatedFx.main.duration);
        Destroy(gameObject);
    }
}
