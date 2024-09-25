using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Key : MonoBehaviour
{
    public UnityEvent onPickUp;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            onPickUp.Invoke();
            Destroy(gameObject);
        }
    }

    public void OnInteract()
    {
        onPickUp.Invoke();
        Destroy(gameObject);
    }
}
