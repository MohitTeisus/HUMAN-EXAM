using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Health : MonoBehaviour
{
    [SerializeField] private float maxHealth;

    public Action<float> OnHealthUpdated;
    public Action OnDeath;

    public bool isDead {  get; private set; }
    private float health;

    void Start()
    {
        health = maxHealth;
        OnHealthUpdated(maxHealth);
    }

    public void DeductHealth(float value)
    {
        if (isDead) return;

        health -= value;

        if(health <= 0)
        {
            isDead = true;
            health = 0;
            OnDeath();
        }

        OnHealthUpdated(health);
    }

}
