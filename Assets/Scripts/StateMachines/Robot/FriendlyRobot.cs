using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FriendlyRobot : MonoBehaviour
{
    public NavMeshAgent agent;
    private RobotState currentState;
    public Transform attachPoint;
    public GameObject attachedObject;

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
}
