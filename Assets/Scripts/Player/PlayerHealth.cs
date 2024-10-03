using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float maxHealth;

    public bool isDead {  get; private set; }
    private float health;

    private void OnEnable()
    {
        Observer.spawnPlayer += ResetHealth;
    }

    private void OnDisable()
    {
        Observer.spawnPlayer -= ResetHealth;
    }

    void Start()
    {
        ResetHealth();
        Observer.onPlayerHit(maxHealth);
    }

    public void DeductHealth(float value)
    {
        if (isDead) return;

        health -= value;

        if(health <= 0)
        {
            isDead = true;
            health = 0;
            Observer.onDeath();
        }

        Observer.onPlayerHit(health);
    }

    private void ResetHealth()
    {
        health = maxHealth;
        isDead = false;
    }
}
