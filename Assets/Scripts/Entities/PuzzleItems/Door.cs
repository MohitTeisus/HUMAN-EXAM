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

    private const float waitTime = 0.4f;

    [SerializeField] private AudioSource openAudio;

    private void OnTriggerEnter(Collider other)
    {
        if (!isLocked && other.CompareTag("Player"))
        {
            timer = 0;
            StartCoroutine(DoorAnimation());
        }
    }

    IEnumerator DoorAnimation()
    {
        while (timer <= waitTime)
        {
            timer += Time.deltaTime;
            yield return null;
        }
            OpenDoor(true);
    }

    private void OnTriggerExit(Collider other)
    {
        StopAllCoroutines();
        if (other.CompareTag("Player"))
        {
            if(doorAnimator.GetBool("Door") == true)
            {
                OpenDoor(false);
            }
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
        if (!isLocked)
        {
            openAudio.Play();
            doorAnimator.SetBool("Door", doorState);
        }
    }
}
