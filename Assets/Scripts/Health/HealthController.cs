using UnityEngine;

public class HealthController : MonoBehaviour
{
    public int CurrentHealth
    {
        get
        {
            return _health;
        }
        set
        {
            _health = value;
        }
    }
    public bool IsDead 
    {
        get
        {
            return _dead;
        }
        set
        {
            _dead = value;
        }
    }

    [SerializeField] private int maxHealth;

    private int _health;
    private bool _dead = false;
    private void Start()
    {
        _health = maxHealth;
    }
    public void DealDamage(int damage)
    {
        CurrentHealth -= damage;
        //invoke health visualizer
        CheckIsAlive();
    }
    private void CheckIsAlive()
    {
        if (CurrentHealth < 0)
        {
            IsDead = true;
            Destroy(gameObject);
        }
    }
}
