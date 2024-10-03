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
    public Image dmgedVignette;
    public GameObject interactUI;
    public GameObject pickupUI;
    public GameObject pauseUI;
    public GameObject gameUI;
    public GameObject tooltipUI;
    public TMP_Text tooltipText;
    public TMP_Text completionTimeText;

    float dmgVignetteTimer;

    float tooltipTimer;
    float tooltipTimeLimit = 5;
    
    private void Update()
    {
        //Slowly makes the dmg ui disappear after not being dmged
        if(dmgVignetteTimer > 0)
        {
            dmgVignetteTimer -= Time.deltaTime * 2;
            dmgedVignette.color = new Color(1, 1, 1, dmgVignetteTimer);
        }

        //makes prompt disappear after timer is over
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
        Observer.UpdatePlayerHealth += UpdateHealth;
        Observer.onDeath += OnDeath;
        Observer.onInteractHover += OnInteractHover;
        Observer.onPickupHover += OnPickUpHover;
        Observer.onPause += OnPause;
        Observer.spawnPlayer += OnRespawn;
        Observer.tooltip += ChangeToolTip;
        Observer.completionTime += UpdateCompletionTime;
    }
    private void OnDisable()
    {
        Observer.UpdatePlayerHealth -= UpdateHealth;
        Observer.onDeath -= OnDeath;
        Observer.onInteractHover -= OnInteractHover;
        Observer.onPickupHover -= OnPickUpHover;
        Observer.onPause -= OnPause;
        Observer.spawnPlayer -= OnRespawn;
        Observer.tooltip -= ChangeToolTip;
        Observer.completionTime -= UpdateCompletionTime;
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
        gameUI.SetActive(false);
    }

    void OnRespawn()
    {
        gameOver.SetActive(false);
        gameUI.SetActive(true);
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

    public void UpdateCompletionTime(float time)
    {
        //formats completion time to text
        int minutes = Mathf.FloorToInt(time / 60);
        string minutesText = minutes.ToString();
        if (minutes < 10)
        {
           minutesText  = "0" + minutes;
        }

        string secondsText = Mathf.FloorToInt(time % 60).ToString();

        completionTimeText.text = "TIME = " + minutesText + ":" + secondsText; 
    }
}
