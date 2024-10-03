using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private EnemyHealth health;

    private void Start()
    {
        
    }

    public void Respawn()
    {
        gameObject.SetActive(true);
        health.ResetHealth();
    }
}
