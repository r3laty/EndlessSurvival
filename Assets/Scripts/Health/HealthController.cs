using System;
using UnityEngine;
using UnityEngine.Events;

public class HealthController : MonoBehaviour
{
    public int MaxHealthProperty => MaxHealth;

    public UnityEvent<int> Visualized;
    public event Action Dead;

    [HideInInspector] public bool IsDead;

    public int MaxHealth;

    private int _health;

    private void Awake()
    {
        _health = MaxHealth;
    }
    private void CheckIsAlive()
    {
        if (_health <= 0)
        {
            IsDead = true;
            Dead?.Invoke();
        }
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
    public void ResetHealth()
    {
        _health = MaxHealth;
    }
}
