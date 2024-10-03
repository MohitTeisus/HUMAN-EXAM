using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDestroyer : MonoBehaviour
{
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
