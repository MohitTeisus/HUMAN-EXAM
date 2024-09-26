using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class DeliveryZone : MonoBehaviour
{
    public Transform[] deliveryPoints;
    public List<GameObject> deliveredObjects = new List<GameObject>();
    private GameObject lastDeliveredItem;

    public UnityEvent deliveryFulfilled; 

    public int spacesFilled = 0;

    private void Start()
    {
        spacesFilled = deliveredObjects.Count;
    }

    public void Deliver(GameObject objToDeliver)
    {
        if (objToDeliver == null) return;
        if (spacesFilled > deliveryPoints.Length) return;
        lastDeliveredItem = objToDeliver;

        if (deliveredObjects.Contains(lastDeliveredItem)) return;

        lastDeliveredItem.transform.position = deliveryPoints[spacesFilled].position;
        lastDeliveredItem.transform.rotation = deliveryPoints[spacesFilled].rotation;
        lastDeliveredItem.transform.parent = deliveryPoints[spacesFilled];
        lastDeliveredItem.GetComponent<Collider>().enabled = false;

        spacesFilled++;
        deliveredObjects.Add(lastDeliveredItem);

        if(spacesFilled == deliveryPoints.Length)
        {
            deliveryFulfilled?.Invoke();
        }
    }
}
