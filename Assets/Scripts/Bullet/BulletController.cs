using System.Collections;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class BulletController : MonoBehaviour
{
    [HideInInspector] public int BulletDamage = 0;
    
    [SerializeField] private float timeToDestroy;
    private void Start()
    {
        StartCoroutine(DestroyAfterTime());
    }
    private IEnumerator DestroyAfterTime()
    {
        Debug.Log($"Damage: {BulletDamage}");
        yield return new WaitForSecondsRealtime(timeToDestroy);
        Destroy(gameObject);
    }
    private void OnDisable()
    {
        StopCoroutine(DestroyAfterTime());
    }
}