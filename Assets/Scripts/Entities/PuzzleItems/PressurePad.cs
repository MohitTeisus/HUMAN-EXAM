using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class PressurePad : MonoBehaviour
{
    [SerializeField] private float checkRadius;
    [SerializeField] private LayerMask pickupLayer;

    public UnityEvent OnObjectPlaced;
    public UnityEvent OnObjectRemoved;

    public string objectTag; //Change which object is required to activated pressure pad

    private void OnTriggerEnter(Collider other)
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, checkRadius, pickupLayer);

        foreach (var collider in hitColliders)
        {
            Debug.Log("Collider in contact = " + collider.gameObject.name);

            if (collider.CompareTag(objectTag))
            {
                OnObjectPlaced?.Invoke();
                Observer.playSound("Button");
                break;
            }
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag(objectTag))
        {
            OnObjectRemoved?.Invoke();
        }
    }
}
