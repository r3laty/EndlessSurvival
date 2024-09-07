using UnityEngine;
using Zenject;

public class CameraCollider : MonoBehaviour
{
    private Transform _target;

    [Inject] private CharacterLoader _characterLoader;
    private void Start()
    {
        _target = _characterLoader.CurrentTransform;
    }
    private void LateUpdate()
    {
        RaycastHit hit;
        Vector3 direction = _target.position - transform.position;
        if (Physics.Raycast(transform.position, direction, out hit, direction.magnitude))
        {
            transform.position = hit.point;
        }
    }
}
