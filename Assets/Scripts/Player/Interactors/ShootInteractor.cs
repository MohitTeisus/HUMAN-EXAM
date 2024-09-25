using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShootInteractor : Interactor
{
    

    [Header("Gun")]
    public MeshRenderer gunRenderer;
    public Color bulletColour;
    public Color rocketColour;

    [Header("Shoot")]
    public ObjectPool bulletPool;
    public ObjectPool rocketPool;

    [SerializeField] private float shootForce;
    [SerializeField] private Transform shootPoint;
    [SerializeField] private PlayerMoveBehaviour moveBehaviour;

    private float finalShootVelocity;
    private IShootStrategy currentShootStrategy;

    public override void Interact()
    {
        if (currentShootStrategy == null)
        {
            currentShootStrategy = new BulletShootStrategy(this);
        }

        if (input.weapon1pressed)
        {
            currentShootStrategy = new BulletShootStrategy(this);
        }

        if (input.weapon2pressed)
        {
            currentShootStrategy = new RocketShootStrategy(this);
        }

        //Shoot strategy
        if (input.primaryShootPressed)
        {
            currentShootStrategy.Shoot();
        }
    }



    /*void Shoot()
    {
        finalShootVelocity = moveBehaviour.GetForwardSpeed() + shootForce;

        PooledObjects pooledObj = objPool.GetPooledObjects();
        pooledObj.gameObject.SetActive(true);

        //Rigidbody bullet = Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);
        Rigidbody bullet = pooledObj.GetComponent<Rigidbody>();

        bullet.transform.position = shootPoint.position;
        bullet.transform.rotation = shootPoint.rotation;

        bullet.velocity = shootPoint.forward * finalShootVelocity;
        
        //Destroy(bullet.gameObject, 5f);

        objPool.DestroyPooledObjects(pooledObj, 5);
    }*/

    public Transform GetShootPoint()
    {
        return shootPoint;
    }

    public float GetShootVelocity()
    {
        finalShootVelocity = moveBehaviour.GetForwardSpeed() + shootForce;
        return finalShootVelocity;
    }
}
