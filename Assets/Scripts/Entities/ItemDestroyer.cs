using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDestroyer : MonoBehaviour
{
    //Used to remove group of objects that the player would try to take to
    //next level when it is not intended
    [SerializeField] private GameObject[] itemsToDestroy;

    public void DisableAllItems()
    {
        foreach (var item in itemsToDestroy)
        {
            item.SetActive(false);
        }
    }

    public void EnableAllItems()
    {
        foreach (var item in itemsToDestroy)
        {
            item.SetActive(true);
        }
    }
}
