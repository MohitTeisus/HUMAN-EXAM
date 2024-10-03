using System.Collections;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMoveBehaviour : MonoBehaviour
{

    private PlayerInput input;

    [Header("Player Movement")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float gravity = -9.81f;
    [SerializeField] private float mass = 1f;
    [SerializeField] private AudioSource footsteps;

    [Header("Ground Checker")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayerMask;
    [SerializeField] private float groundCheckDistance;

    private CharacterController characterController;

    private Vector3 playerVelocity;
    public bool isGrounded {get; private set;}

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        input = PlayerInput.GetInstance();
    }

    // Update is called once per frame
    void Update()
    {
        GroundCheck();
        MovePlayer();
    }

    void MovePlayer()
    {
        characterController.Move((transform.forward * input.vertical + transform.right * input.horizontal) * moveSpeed * Time.deltaTime);

        //Groundcheck
        if (isGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = -2f;
        }

        playerVelocity.y += gravity * mass * Time.deltaTime;

        characterController.Move(playerVelocity * Time.deltaTime);

        if (input.vertical > Mathf.Abs(0.05f) || input.horizontal > Mathf.Abs(0.05f))
        {
            footsteps.pitch = Random.Range(0.8f, 1.0f);
            footsteps.Play();
        }
        else
        {
            footsteps.Pause();
        }
    }

    void GroundCheck()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundCheckDistance, groundLayerMask);
    }

    public void SetYVelocity(float value)
    {
        playerVelocity.y = value;
    }

    public float GetForwardSpeed()
    {
        return input.vertical * moveSpeed;
    }
}
