using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private PooledObjects pooledOBJ;
    [SerializeField] private float damage;

    private void OnCollisionEnter(Collision other)
    {
        IDestroyable destroyable = other.gameObject.GetComponent<IDestroyable>();
        if ( destroyable != null)
        {
            destroyable.OnCollided();
        }

        IDamageable damageable = other.gameObject.GetComponent<IDamageable>();
        if ( damageable != null )
        {
            damageable.GetDamage(damage);
        }
        pooledOBJ.Destroy(0.5f);
    }

    private void OnTriggerEnter(Collider other)
    {
        IShootable shootable = other.gameObject.GetComponent<IShootable>();

        if ( shootable != null )
        {
            shootable.OnHit();
            pooledOBJ.Destroy();
        }
    }
}
