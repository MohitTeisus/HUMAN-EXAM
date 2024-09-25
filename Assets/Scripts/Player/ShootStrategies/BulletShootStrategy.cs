using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShootStrategy : IShootStrategy
{
    ShootInteractor interactor;
    Transform shootPoint;

    public BulletShootStrategy (ShootInteractor _interactor)
    {
        Debug.Log("switched to bullet mode");
        this.interactor = _interactor;
        shootPoint = interactor.GetShootPoint();

        //Change colour of the gun
        interactor.gunRenderer.material.color = interactor.bulletColour;
    }

    public void Shoot()
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
