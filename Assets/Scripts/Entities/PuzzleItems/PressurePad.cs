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

    public string objectTag;

    private void OnTriggerEnter(Collider other)
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, checkRadius, pickupLayer);

        foreach (var collider in hitColliders)
        {
            Debug.Log("Collider in contact = " + collider.gameObject.name);

            if (collider.CompareTag(objectTag))
            {
                OnObjectPlaced?.Invoke();
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

    /* private void OnCollisionEnter(Collision collision)
     { 
         //Check if the collider of the cube is close enough to the center of the pressure pad
         Collider[] hitColliders = Physics.OverlapSphere(transform.position, checkRadius, pickupLayer);

         foreach (var collider in hitColliders)
         {
             Debug.Log("Collider in contact = " + collider.gameObject.name);

             if (collider.CompareTag("PickCube") || collider.CompareTag("Player"))
             {
                 OnCubePlaced?.Invoke();
                 break;
             }
         }
     }*/
/*
    public void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("PickCube") || collision.gameObject.CompareTag("Player"))
        {
            OnCubeRemoved?.Invoke();
        }
    }*/

}
