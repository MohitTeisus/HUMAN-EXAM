using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketShootStrategy : IShootStrategy
{
    ShootInteractor interactor;
    Transform shootPoint;

    public RocketShootStrategy(ShootInteractor _interactor)
    {
        Debug.Log("switched to rocket mode");
        this.interactor = _interactor;
        shootPoint = interactor.GetShootPoint();

        interactor.gunRenderer.material.color = interactor.rocketColour;
    }

    public void Shoot()
    {
        PooledObjects pooledObj = interactor.rocketPool.GetPooledObjects();
        pooledObj.gameObject.SetActive(true);

        //Rigidbody bullet = Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);
        Rigidbody bullet = pooledObj.GetComponent<Rigidbody>();

        bullet.transform.position = shootPoint.position;
        bullet.transform.rotation = shootPoint.rotation;

        bullet.velocity = shootPoint.forward * interactor.GetShootVelocity();

        //Destroy(bullet.gameObject, 5f);

        interactor.rocketPool.DestroyPooledObjects(pooledObj, 5);
    }
}
