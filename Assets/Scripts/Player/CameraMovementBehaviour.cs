using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class CameraMovementBehaviour : MonoBehaviour
{
    private PlayerInput input;

    [Header("Camera Turn")]
    [SerializeField] private float turnSpeed;
    [SerializeField] private bool invertMouse;
    
    private float camXRotation;
    bool isPaused;

    private void OnEnable()
    {
        Observer.onPause += OnGamePause;
        Observer.onDeath += EnableCursor;
        Observer.spawnPlayer += DisableCursor;
    }

    private void OnDisable()
    {
        Observer.onPause -= OnGamePause;
        Observer.onDeath -= EnableCursor;
        Observer.spawnPlayer -= DisableCursor;
    }

    // Start is called before the first frame update
    void Start()
    {
        DisableCursor();
        input = PlayerInput.GetInstance();
    }

    // Update is called once per frame
    void Update()
    {
        RotateCamera();
    }

    void RotateCamera()
    {
        if (isPaused) return;

        camXRotation += Time.deltaTime * input.mouseY * turnSpeed * (invertMouse ? 1 : -1);
        camXRotation = Mathf.Clamp(camXRotation, -60f, 75f);

        gameObject.transform.localRotation = Quaternion.Euler(camXRotation, 0, 0);
    }

    public void OnGamePause(bool paused)
    {
        if (paused)
        {
            EnableCursor();
        }
        else
        {
            DisableCursor();
        }
        isPaused = paused;
    }

    public void DisableCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void EnableCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
