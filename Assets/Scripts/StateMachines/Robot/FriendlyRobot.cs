using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FriendlyRobot : MonoBehaviour
{
    public NavMeshAgent agent;
    private RobotState currentState;
    private bool isActive = true;    

    public Transform attachPoint;
    public GameObject attachedObject;

    public Transform completionPoint;

    // Start is called before the first frame update
    void Start()
    {
        currentState = new RobotDefaultState(this);
        currentState.OnStateEnter();   
    }

    // Update is called once per frame
    void Update()
    {
        currentState.OnStateUpdate();
    }

    public void ChangeState(RobotState state)
    {
        currentState.OnStateExit();
        currentState = state;
        currentState.OnStateEnter();
    }

    private void OnTriggerEnter(Collider other)
    {
        currentState.OnCollisionEnter(other);
    }

    public void SetActivity(bool activity)
    {
        isActive = activity;

        if (!isActive)
        {
            ChangeState(new RobotDeactivatedState(this));
        }
    }

    public bool GetActivity()
    {
        return isActive;
    }
}
