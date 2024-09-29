using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Vector3 spawnPoint;
    [SerializeField] private EnemyHealth health;

    private void Start()
    {
        //spawnPoint = transform.position;   
    }

    public void Respawn()
    {
        gameObject.SetActive(true);
        //transform.position = spawnPoint;
        health.ResetHealth();
    }
}
