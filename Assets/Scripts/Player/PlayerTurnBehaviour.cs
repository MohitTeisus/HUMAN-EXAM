using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerTurnBehaviour : MonoBehaviour
{
    private PlayerInput input;

    [Header("Player Turn")]
    [SerializeField] private float turnSpeed;
    private float maxTurnspeed = 350;

    private void OnEnable()
    {
        Observer.changeSensitivity += ChangeSensitivity;
    }

    private void OnDisable()
    {
        Observer.changeSensitivity -= ChangeSensitivity;
    }

    // Start is called before the first frame update
    void Start()
    {
        input = PlayerInput.GetInstance();
    }

    // Update is called once per frame
    void Update()
    {
        RotatePlayer();
    }

    void RotatePlayer()
    {
        transform.Rotate(Vector3.up * turnSpeed * Time.deltaTime * input.mouseX);
    }

    void ChangeSensitivity(float multiplier)
    {
        turnSpeed = multiplier * maxTurnspeed;
    }
}
