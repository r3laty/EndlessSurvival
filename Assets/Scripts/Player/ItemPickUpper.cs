using UnityEngine;

public class ItemPickUpper : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Booster"))
        {
            other.gameObject.TryGetComponent<IBoostable>(out IBoostable boostable);
            
            var boostableCollider = other.gameObject.GetComponent<BoxCollider>();
            var boostableMesh = other.gameObject.GetComponentInChildren<MeshRenderer>();

            if (boostable != null)
            {
                Debug.Log($"{boostable.GetType()} on trigger enter");

                boostableCollider.enabled = false;
                boostableMesh.enabled = false;

                boostable.Execute();
            }
        }
    }
}
