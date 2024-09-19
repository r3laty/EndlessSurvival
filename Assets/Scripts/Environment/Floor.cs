using System.Collections;
using UnityEngine;
using Zenject;

public class Floor : MonoBehaviour
{
    private Grenade _grenade;
    [Inject] private BaseGun _gun;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(TagManager.GrenadeTag))
        {
            if (_gun is GrenadeLauncher launcher)
            {
                if (launcher.CurrentGrenade != null)
                {
                    _grenade = launcher.CurrentGrenade;
                }
            }
            StartCoroutine(OwnInvoke(1.2f));
        }
    }
    private IEnumerator OwnInvoke(float time)
    {
        yield return new WaitForSeconds(time);
        _grenade.Explode();
    }
}
