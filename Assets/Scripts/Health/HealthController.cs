using System;
using UnityEngine;
using UnityEngine.Events;

public class HealthController : MonoBehaviour
{
    public int CurrentHealth => _currentHealth;
    public UnityEvent<int> Visualized;
    public event Action Dead;

    [HideInInspector] public bool IsDead;

    public int MaxHealth;

    private int _currentHealth;

    private void Awake()
    {
        _currentHealth = MaxHealth;
    }
    private void CheckIsAlive()
    {
        if (_currentHealth <= 0)
        {
            IsDead = true;
            Dead?.Invoke();
        }
    }
    public void DealDamage(int damage)
    {
        _currentHealth -= damage;
        Visualized?.Invoke(_currentHealth);
        CheckIsAlive();
    }
    public void RestoreHealth(int amount)
    {
        _currentHealth += amount;

        if(_currentHealth > amount)
        {
            _currentHealth = MaxHealth;
        }
        Visualized?.Invoke(_currentHealth);
    }
    public void ResetHealth()
    {
        _currentHealth = MaxHealth;
    }
}
