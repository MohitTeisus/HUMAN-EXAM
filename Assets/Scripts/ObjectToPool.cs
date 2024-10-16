using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectToPool : MonoBehaviour
{
    ObjectPooling associatedPool;

    private float timer;
    private bool setToDestroy = false;
    private float destroyTime = 0;

    public void SetObjectPool(ObjectPooling pool)
    {
        associatedPool = pool;
        timer = 0;
        destroyTime = 0;
        setToDestroy = false;
    }

    private void Update()
    {
        if (setToDestroy)
        {
            timer += Time.deltaTime;

            if (timer >= destroyTime)
            {
                timer = 0;
                setToDestroy = false;
                Destroy();
            }
        }
    }

    public void Destroy()
    {
        if (associatedPool != null)
        {
            associatedPool.RestoreObjects(this);
        }
    }

    public void Destroy(float time)
    {
        setToDestroy = true;
        destroyTime = time;
    }
}
