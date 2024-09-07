using Cinemachine;
using UnityEngine;
using Zenject;

public class SetVirtualCamera : MonoBehaviour
{
    [SerializeField] private float smoothTime = 0.3f;

    [SerializeField] private Vector3 offset = new Vector3(0, 9, -13);

    [SerializeField] private CinemachineVirtualCamera virtualCam;

    private Transform _target => _characterLoader.CurrentTransform;
    private Vector3 _velocity = Vector3.zero;

    [Inject] private CharacterLoader _characterLoader;
    private void Start()
    {
        SetLookAt();
    }
    private void Update()
    {
        SetFollow();
    }
    private void SetFollow()
    {
        if (_target != null)
        {
            Vector3 targetPosition = _target.position + offset;

            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref _velocity, smoothTime);
        }
    }
    private void SetLookAt()
    {
        virtualCam.LookAt = _target;
    }
}
