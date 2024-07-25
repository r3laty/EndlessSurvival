using UnityEngine;
using UnityEngine.Events;

public class HealthController : MonoBehaviour
{
    public UnityEvent<int> Visualized;


    /*[HideInInspector] */public bool IsDead;
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
        Visualized?.Invoke(_health);
        CheckIsAlive();
    }
    public void RestoreHealth(int amount)
    {
        _health += amount;

        if(_health > amount)
        {
            _health = MaxHealth;
        }
        Visualized?.Invoke(_health);
    }
    private void CheckIsAlive()
    {
        if (_health <= 0)
        {
            IsDead = true;
            //gameObject.SetActive(false);
            //Destroy(gameObject);
        }
    }
}
