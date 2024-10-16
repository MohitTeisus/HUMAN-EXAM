using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    public GameObject objectToPool;
    public int startSize;

    [SerializeField] private List<ObjectToPool> objectPool = new List<ObjectToPool>();
    [SerializeField] private List<ObjectToPool> usedPool = new List<ObjectToPool>();

    private ObjectToPool tempObj;

    // Start is called before the first frame update
    void Start()
    {
        InitialisePool();
    }

    void InitialisePool()
    {
        for (int i = 0; i < startSize; i++)
        {
            AddNewObject();
        }
    }

    void AddNewObject()
    {
        tempObj = Instantiate(objectToPool, transform).GetComponent<ObjectToPool>();
        tempObj.gameObject.SetActive(false);
        tempObj.SetObjectPool(this);
        objectPool.Add(tempObj);
    }

    public ObjectToPool GetPooledObjects()
    {
        ObjectToPool tempObject;
        if (objectPool.Count > 0)
        {
            tempObject = objectPool[0];
            usedPool.Add(tempObject);
            objectPool.RemoveAt(0);
        }
        else
        {
            AddNewObject();
            tempObject = GetPooledObjects();
        }

        tempObject.gameObject.SetActive(true);
        return tempObject;
    }

    public void DestroyPooledObjects(ObjectToPool obj, float time = 0)
    {
        if (time == 0)
        {
            obj.Destroy();
        }
        else
        {
            obj.Destroy(time);
        }
    }

    public void RestoreObjects(ObjectToPool obj)
    {
        obj.gameObject.SetActive(false);
        usedPool.Remove(obj);
        objectPool.Add(obj);
    }
}
