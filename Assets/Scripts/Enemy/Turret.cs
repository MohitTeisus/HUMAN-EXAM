using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private TurretState currentState;

    public Transform turretGun;
    public float playerCheckDistance;

    public float damagePerSecond = 25;
    [HideInInspector] public Transform player;
    [SerializeField] private LineRenderer lineRenderer;

    // Start is called before the first frame update
    void Start()
    {
        currentState = new TurretIdleState(this);
        currentState.OnStateEnter();
        DrawLaser(turretGun.position + turretGun.forward * playerCheckDistance); 
    }

    // Update is called once per frame
    void Update()
    {
        currentState.OnStateUpdate();
    }

    public void ChangeTurretState(TurretState state)
    {
        currentState.OnStateExit();
        currentState = state;
        currentState.OnStateEnter();
    }

    public void DrawLaser(Vector3 linePosition)
    {
        //line start position
        lineRenderer.SetPosition(0, turretGun.position);
        //line end position
        lineRenderer.SetPosition(1, linePosition);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(turretGun.position, .3f);
        Gizmos.DrawWireSphere(turretGun.position + turretGun.forward * playerCheckDistance, .3f);

        Gizmos.DrawLine(turretGun.position, turretGun.position + turretGun.forward * playerCheckDistance);
    }
}
