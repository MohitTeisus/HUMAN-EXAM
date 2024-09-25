using System.Collections;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Runtime.CompilerServices;
using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class PlayerMoveBehaviour : MonoBehaviour
{

    private PlayerInput input;

    [Header("Player Movement")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float sprintMult;
    [SerializeField] private float gravity = -9.81f;
    [SerializeField] private float mass = 1f;

    [Header("Ground Checker")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayerMask;
    [SerializeField] private float groundCheckDistance;

    private CharacterController characterController;

    private float moveMult = 1;
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
        moveMult = input.sprintHeld ? sprintMult : 1;
        characterController.Move((transform.forward * input.vertical + transform.right * input.horizontal) * moveSpeed * Time.deltaTime * moveMult);

        //Groundcheck
        if (isGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = -2f;
        }

        playerVelocity.y += gravity * mass * Time.deltaTime;

        characterController.Move(playerVelocity * Time.deltaTime);
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
        return input.vertical * moveSpeed * moveMult;
    }
}
