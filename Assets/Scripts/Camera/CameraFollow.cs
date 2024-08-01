using UnityEngine;
using Zenject;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private float smoothTime = 0.3f;

    [SerializeField] private Vector3 offset;

    [Inject] private CharacterLoader _characterLoader;

    private Vector3 _velocity = Vector3.zero;
    private Transform target;
    private void Start()
    {
        target = _characterLoader.CurrentTransform;
    }
    private void Update()
    {
        if (target != null)
        {
            Vector3 targetPosition = target.position + offset;

            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref _velocity, smoothTime);
        }
    }
}
