using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Health playerHealth;

    [Header("UI Element")]
    public TMP_Text txtHealth;
    public GameObject gameOver;

    // Start is called before the first frame update
    void Start()
    {
        gameOver.SetActive(false);
    }

    private void OnDestroy()
    {
        playerHealth.OnHealthUpdated -= OnHealthUpdated;
    }

    private void OnEnable()
    {
        playerHealth.OnHealthUpdated += OnHealthUpdated;
        playerHealth.OnDeath += OnDeath;
    }

    void OnHealthUpdated(float health)
    {
        txtHealth.text = "Health : " + Mathf.Floor(health);
    }

    void OnDeath()
    {
        gameOver.SetActive(true);
    }
}
