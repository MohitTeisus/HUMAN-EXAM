using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private PooledObjects pooledOBJ;
    [SerializeField] private float damage;

    private void OnCollisionEnter(Collision other)
    {
        //Debug.Log($"Collided with {other.gameObject.name}");
        pooledOBJ.Destroy(1f);

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
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log($"Collided with {other.gameObject.name}");

        IShootable shootable = other.gameObject.GetComponent<IShootable>();

        if ( shootable != null )
        {
            shootable.OnHit();
            pooledOBJ.Destroy();
        }
    }
}
