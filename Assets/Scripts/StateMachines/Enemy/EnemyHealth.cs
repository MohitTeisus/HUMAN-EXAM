using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour, IDamageable
{
    [SerializeField] private float maxHealth;
    private float currentHealth;

    public Action<float, float> onHealthUpdate; //float 1 for damage dealt, float 2 for max health

    [SerializeField] EnemyAudio enemyAudio;
    private void Start()
    {
        ResetHealth();
    }

    public void GetDamage(float damage)
    {
        enemyAudio.PlayHitSound();
        if (currentHealth > 0)
        {
            currentHealth -= damage;
        }

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            DestroyEnemy();
        }
        onHealthUpdate?.Invoke(damage,maxHealth);
    }

    private void DestroyEnemy()
    {
        if (gameObject != null)
        {
            gameObject.SetActive(false);
        }
    }

    public void ResetHealth()
    {
        currentHealth = maxHealth;
    }


}
