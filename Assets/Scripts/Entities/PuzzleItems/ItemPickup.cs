using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class ItemPickup : MonoBehaviour
{
    public UnityEvent onPickUp;
    [SerializeField] private LayerMask playerLayer;
    private GameObject player;
    private float movespeed = 2.5f;
    public float pickupRadius = 3f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            onPickUp.Invoke();
            Observer.playSound("ItemPickedUp");
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        PullTowardPlayer();
    }

    //When the Player gets close to the item, the items pulls towards the player
    private void PullTowardPlayer()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, pickupRadius, playerLayer);

        foreach (Collider collider in colliders)
        {
            if (collider.transform.CompareTag("Player"))
            {
                player = collider.gameObject;
            }
        }

        if (player != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, movespeed * Time.deltaTime);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, pickupRadius);
    }
}
