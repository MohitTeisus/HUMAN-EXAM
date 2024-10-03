using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[DefaultExecutionOrder(-100)]
public class PlayerInput : MonoBehaviour
{
    public float horizontal { get; private set; }

    public float vertical { get; private set; }

    public float mouseX { get; private set; }

    public float mouseY { get; private set; }

    public bool jumpPressed { get; private set; }

    public bool activatePressed { get; private set; }

    public bool primaryShootPressed { get; private set; }

    public bool weapon1pressed { get; private set; }

    public bool weapon2pressed { get; private set; }

    public bool weapon3pressed { get; private set; }

    public bool pausePressed {  get; private set; }

    private bool clear;

    private bool isPaused;
    private bool isDead;

    //Singleton
    private static PlayerInput instance;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
            return;
        }
        instance = this;
    }

    public static PlayerInput GetInstance()
    {
        return instance;
    }

    private void OnEnable()
    {
        Observer.onPause += PauseInputs;
        Observer.onDeath += OnDeath;
    }

    private void OnDisable()
    {
        Observer.onPause -= PauseInputs;
        Observer.onDeath -= OnDeath;
    }

    // Update is called once per frame
    void Update()
    {
        ClearInputs();
        ProcessInputs();
    }

    void ProcessInputs()
    {
        if (isDead) return;

        pausePressed = Input.GetButtonDown("Pause");

        if (isPaused) return;

        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");

        jumpPressed = jumpPressed || Input.GetButtonDown("Jump");
        activatePressed = activatePressed || Input.GetKeyDown(KeyCode.E);

        primaryShootPressed = primaryShootPressed || Input.GetButtonDown("Fire1");

        weapon1pressed = weapon1pressed || Input.GetKeyDown(KeyCode.Alpha1);
        weapon2pressed = weapon2pressed || Input.GetKeyDown(KeyCode.Alpha2);
        weapon3pressed = weapon3pressed || Input.GetKeyDown(KeyCode.Alpha3);
    }

    private void FixedUpdate()
    {
        clear = true;
    }

    void ClearInputs()
    {
        if (!clear)
            return;

        horizontal = 0;
        vertical = 0;
        mouseX = 0;
        mouseY = 0;

        jumpPressed = false;
        activatePressed = false;

        //pausePressed = false;
        primaryShootPressed = false;

        weapon1pressed = false;
        weapon2pressed = false;
        weapon3pressed = false;
    }

    void OnDeath()
    {
        isDead = true;
    }

    void Respawn()
    {
        isDead = false;
    }

    void PauseInputs(bool paused)
    {
        isPaused = paused;
    }
}
