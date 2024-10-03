using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAudio : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip dmgSFX;

    public void PlayHitSound()
    {
        audioSource.pitch = Random.Range(0.8f, 1.0f);
        audioSource.PlayOneShot(dmgSFX);
    }
}
