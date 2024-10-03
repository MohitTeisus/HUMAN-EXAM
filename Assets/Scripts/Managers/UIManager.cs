using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("UI Element")]
    public TMP_Text txtHealth;
    public GameObject gameOver;
    public GameObject crosshair;
    public Image dmgedVignette;
    public GameObject interactUI;
    public GameObject pickupUI;
    public GameObject pauseUI;
    public GameObject gameUI;
    public GameObject tooltipUI;
    public TMP_Text tooltipText;

    float dmgVignetteTimer;

    float tooltipTimer;
    float tooltipTimeLimit = 5;
    // Start is called before the first frame update
    void Start()
    {
        gameOver.SetActive(false);
        crosshair.SetActive(true);
    }

    private void Update()
    {
        //Slowly makes the dmg ui disappear after not being dmged
        if(dmgVignetteTimer > 0)
        {
            dmgVignetteTimer -= Time.deltaTime * 2;
            dmgedVignette.color = new Color(1, 1, 1, dmgVignetteTimer);
        }

        //Displays prompt for level completed
        if (tooltipTimer < 0)
        {
            tooltipUI.SetActive(false);  
        }
        else
        {
            tooltipTimer -= Time.deltaTime;
        }
    }
    private void OnEnable()
    {
        Observer.onPlayerHit += UpdateHealth;
        Observer.onDeath += OnDeath;
        Observer.onInteractHover += OnInteractHover;
        Observer.onPickupHover += OnPickUpHover;
        Observer.onPause += OnPause;
    }
    private void OnDisable()
    {
        Observer.onPlayerHit -= UpdateHealth;
        Observer.onDeath -= OnDeath;
        Observer.onInteractHover -= OnInteractHover;
        Observer.onPickupHover -= OnPickUpHover;
        Observer.onPause -= OnPause;
    }
    
    void UpdateHealth(float health) //Updates HP in UI
    {
        txtHealth.text = "Health : " + Mathf.Floor(health);

        //Sets dmgVignette to visible
        dmgVignetteTimer = 1;
        dmgedVignette.color = new Color(1, 1, 1, 1);
    }

    void OnDeath() //When the player dies, Enables gameover UI
    {
        gameOver.SetActive(true);
        crosshair.SetActive(false);
    }

    void OnInteractHover(bool hovered) //When the player hovers over an interactable object, a prompt appears
    {
        interactUI.SetActive(hovered);
    }

    void OnPickUpHover(bool hovered) //When the player hovers over a pickable object, a prompt appears
    {
        pickupUI.SetActive(hovered);
    }

    void OnPause(bool pause) //Displays pause menu
    {
        pauseUI.SetActive(pause);
        gameUI.SetActive(!pause);
    }

    public void OnLevelComplete()
    {
        tooltipTimer = tooltipTimeLimit;
        tooltipUI.SetActive(true);
        tooltipText.text = "LEVEL COMPLETED PROCEED TO EXIT";
    }

    public void OnKeySpawn()
    {
        tooltipTimer = tooltipTimeLimit;
        tooltipUI.SetActive(true);
        tooltipText.text = "KEYCARD NOW AVAILABLE";
    }

    public void ChangeToolTip(string text)
    {
        tooltipTimer = tooltipTimeLimit;
        tooltipUI.SetActive(true);
        tooltipText.text = text;
    }
}
