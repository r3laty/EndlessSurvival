using System.Collections;
using UnityEngine;
using FMODUnity;
using System;

public class ItemPickUpper : MonoBehaviour
{
    public int PickUpedCount => _pickUpedCount;

    public event Action<IBoostable> BoostCreated;

    [SerializeField] private EventReference collectedSound;
    [Space]
    [SerializeField] private float pickUpDelay = 2;

    private bool _canPickUp = true;
    private int _pickUpedCount = 0;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(TagManager.BoosterTag))
        {
            if (_canPickUp)
            {
                if (AudioManager.Instance != null)
                {
                    AudioManager.Instance.PlayOneShot(collectedSound, this.transform.position);
                }
                other.gameObject.TryGetComponent<IBoostable>(out IBoostable boostable);

                var boostableCollider = other.gameObject.GetComponent<BoxCollider>();
                var boostableMesh = other.gameObject.GetComponentInChildren<MeshRenderer>();
                var boostableCanvas = other.gameObject.GetComponentInChildren<Canvas>();

                if (boostable != null)
                {
                    boostableCollider.enabled = false;
                    boostableMesh.enabled = false;
                    boostableCanvas.enabled = false;

                    BoostCreated?.Invoke(boostable);
                    boostable.Execute();

                    _pickUpedCount++;
                }
            }
            StartCoroutine(BoostersDelay());
        }
    }
    private IEnumerator BoostersDelay()
    {
        _canPickUp = false;
        yield return new WaitForSeconds(pickUpDelay);
        _canPickUp = true;
    }
}
