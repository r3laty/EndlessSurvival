using UnityEngine;
using Zenject;

public class Death : MonoBehaviour
{
    [SerializeField] private Canvas deathMenu;

    [Inject] private Shooting _shooting;

    private HealthController _healthController;

    private void Awake()
    {
        _healthController = GetComponent<HealthController>();
        _healthController.Dead += OnDeath;
    }
    private void OnDeath()
    {
        _shooting.enabled = false;
        deathMenu.gameObject.SetActive(true);
        Time.timeScale = 0;
    }
    private void OnDisable()
    {
        _healthController.Dead -= OnDeath;
    }
}
