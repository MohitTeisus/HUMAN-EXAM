using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShootStrategy : IEquipStrategy
{
    EquipInteractor interactor;
    Transform shootPoint;

    public BulletShootStrategy (EquipInteractor _interactor)
    {
        Debug.Log("switched to bullet mode");
        this.interactor = _interactor;
        shootPoint = interactor.GetShootPoint();
        
        //Equip gun
        interactor.gun.SetActive(true);
    }

    public void UseEquipment()
    {
        PooledObjects pooledObj = interactor.bulletPool.GetPooledObjects();
        pooledObj.gameObject.SetActive(true);

        //Rigidbody bullet = Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);
        Rigidbody bullet = pooledObj.GetComponent<Rigidbody>();

        bullet.transform.position = shootPoint.position;
        bullet.transform.rotation = shootPoint.rotation;

        bullet.velocity = shootPoint.forward * interactor.GetShootVelocity() + new Vector3 (Random.Range(0,1f), Random.Range(0, 1f), 0);

        //Destroy(bullet.gameObject, 5f);

        interactor.bulletPool.DestroyPooledObjects(pooledObj, 5);
    }
}
