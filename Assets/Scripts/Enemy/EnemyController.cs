using System;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public static event Action<bool> IsAvavailableToAttack;

    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float distanceToPlayer = 4f;
    [Space]
    [SerializeField] private string movementAnimatorParametr;
    [SerializeField] private string attackAnimatorParametr;

    private Transform _player;
    private Animator _animator;
    private bool _isMoving = true;
    private void Awake()
    {
        _player = GameObject.FindGameObjectWithTag(TagManager.PlayerTag).transform;
        _animator = GetComponentInChildren<Animator>();
    }
    private void Update()
    {
        transform.LookAt(_player.position);

        Moving();
        SetAnimations();
    }
    private void SetAnimations()
    {
        if (Vector3.Distance(transform.position, _player.position) < distanceToPlayer)
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
            transform.position = Vector3.MoveTowards(transform.position, _player.position, moveSpeed * Time.deltaTime);
        }
    }
}
