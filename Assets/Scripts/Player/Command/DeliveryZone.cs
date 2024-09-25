using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DeliveryZone : MonoBehaviour
{
    public Transform[] deliveryPoints;
    public List<GameObject> deliveredObjects = new List<GameObject>();
    private GameObject deliveredItem;

    public int spacesFilled = 0;


    private void Update()
    {
        //Debug.Log("List = " + deliveredObjects.Count);
    }
    public void Deliver(GameObject objToDeliver)
    {
        if (objToDeliver == null) return;
        if (spacesFilled > deliveryPoints.Length) return;
        if (deliveredObjects.Contains(deliveredItem)) return;

        deliveredItem = objToDeliver;
        deliveredItem.transform.position = deliveryPoints[spacesFilled].position;
        deliveredItem.transform.parent = deliveryPoints[spacesFilled];
        spacesFilled++;
        deliveredItem.GetComponent<Collider>().enabled = false;
        deliveredObjects.Add(deliveredItem);
    }
}
