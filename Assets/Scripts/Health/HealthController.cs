using UnityEngine;

public class HealthController : MonoBehaviour
{
    public bool IsDead { get; set; }

    public int MaxHealth;

    private int _health;
    private void Start()
    {
        _health = MaxHealth;
        Debug.Log($"{gameObject.name} has {_health} hp");
    }
    public void DealDamage(int damage)
    {
        _health -= damage;
        //invoke health visualizer
        CheckIsAlive();
    }
    private void CheckIsAlive()
    {
        if (_health < 0)
        {
            IsDead = true;
            Destroy(gameObject);
        }
    }
}
