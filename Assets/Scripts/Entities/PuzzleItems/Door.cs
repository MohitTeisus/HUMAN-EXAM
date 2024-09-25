using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Door : MonoBehaviour
{
    //[SerializeField] private MeshRenderer doorRenderer;
    //[SerializeField] private Material defaultDoorMaterial, detectedDoorMaterial;
    [SerializeField] private Animator doorAnimator;

    private bool isLocked = true;
    private float timer = 0;

    private const float waitTime = 0.25f;

    private void OnTriggerEnter(Collider other)
    {
        if (!isLocked && other.CompareTag("Player"))
        {
            //Reset the timer and also change the colour of the door
            timer = 0;
            //doorRenderer.material = detectedDoorMaterial;

        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (isLocked) return;

        if (!other.CompareTag("Player")) return;

        timer += Time.deltaTime;

        if (timer >= waitTime)
        {
            timer = waitTime;
            OpenDoor(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //doorRenderer.material = defaultDoorMaterial;
            OpenDoor(false);
        }
    }

    public void LockDoor()
    {
        isLocked = true;
    }

    public void UnlockDoor()
    {
        isLocked = false;
    }

    public void OpenDoor(bool doorState)
    {
        if(!isLocked)
            doorAnimator.SetBool("Door", doorState);
    }
}
