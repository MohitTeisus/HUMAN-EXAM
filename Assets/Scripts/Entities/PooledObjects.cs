using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PooledObjects : MonoBehaviour
{
    ObjectPool associatedPool;

    private float timer;
    private bool setToDestroy = false;
    private float destoryTime = 0;

    public void SetObjectPool(ObjectPool pool)
    {
        associatedPool = pool;
        timer = 0;
        destoryTime = 0;
        setToDestroy = false;
    }

    private void Update()
    {
        if (setToDestroy)
        {
            timer += Time.deltaTime;

            if (timer >= destoryTime)
            {
                timer = 0;
                setToDestroy = false;
                Destroy();
            }
        }
    }

    public void Destroy()
    {
        if(associatedPool != null)
        {
            associatedPool.RestoreObjects(this);
        }
    }

    public void Destroy(float time)
    {
        setToDestroy = true;
        destoryTime = time;
    }
}
