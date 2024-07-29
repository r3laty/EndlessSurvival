using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [HideInInspector] public Transform Player;

    [SerializeField] private Transform bulletSpawnPoint;
    [Space]
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float distanceToPlayer = 4f;
    [Space]
    [SerializeField] private string movementAnimatorParametr;
    [SerializeField] private string attackAnimatorParametr;
    [Space]
    [SerializeField] private GameObject baff;

    private Animator _animator;
    private HealthController _healthController;
    private bool _isMoving = true;
    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
        _healthController = GetComponent<HealthController>();
        _healthController.Dead += OnDeath;
    }
    private void Update()
    {
        transform.LookAt(Player.position);

        Moving();
        SetAnimations();
    }
    private void SetAnimations()
    {
        if (Vector3.Distance(transform.position, Player.position) < distanceToPlayer)
        {
            _isMoving = false;
            _animator.SetBool(movementAnimatorParametr, false);
            _animator.SetTrigger(attackAnimatorParametr);
        }
        else
        {
            _isMoving = true;
            _animator.SetBool(movementAnimatorParametr, true);
        }
    }
    private void Moving()
    {
        if (_isMoving)
        {
            transform.position = Vector3.MoveTowards(transform.position, Player.position, moveSpeed * Time.deltaTime);
        }
    }
    private void OnDeath()
    {
        var instatiatedBaff = Instantiate(baff, bulletSpawnPoint.position, Quaternion.identity);
        gameObject.SetActive(false);
    }
    private void OnDisable()
    {
        _healthController.Dead -= OnDeath;
    }
}
