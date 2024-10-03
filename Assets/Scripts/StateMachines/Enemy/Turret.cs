using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private TurretState currentState;

    public Transform turretGun;
    public float playerCheckDistance;
    public float checkRadius;
    public float damagePerSecond = 25;
    [HideInInspector] public Transform player;
    public LineRenderer lineRenderer;
    public AudioSource turretAudio;

    bool isActive = true;

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
        Gizmos.DrawWireSphere(turretGun.position, checkRadius);
        Gizmos.DrawWireSphere(turretGun.position + turretGun.forward * playerCheckDistance, checkRadius);

        Gizmos.DrawLine(turretGun.position, turretGun.position + turretGun.forward * playerCheckDistance);
    }

    public void DisableTurret()
    {
        if (!isActive) return;

        isActive = false;
        currentState.OnStateExit();
        currentState = new TurretDisabledState(this);
        currentState.OnStateEnter();
    }

    public void EnableTurret()
    {
        if(isActive) return;

        isActive = false;

        currentState.OnStateExit();
        currentState = new TurretIdleState(this);
        currentState.OnStateEnter();
    }
}
