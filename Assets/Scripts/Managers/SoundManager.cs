using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    //Controls most important audio sources using the Observer design pattern
    [Header("Audio Sources")]
    [SerializeField] AudioSource playerAudio; 
    [SerializeField] AudioSource gunAudio;
    [SerializeField] AudioSource globalAudio;

    [Header("Audio Clips")]
    [SerializeField] AudioClip playerDMGed;
    [SerializeField] AudioClip gunShot;
    [SerializeField] AudioClip buttonPressed;
    [SerializeField] AudioClip itemPickedUp;
    [SerializeField] AudioClip levelComplete;
    [SerializeField] AudioClip command;
    [SerializeField] AudioClip door;
    [SerializeField] AudioClip typing;

    private void OnEnable()
    {
        Observer.playSound += PlaySound;
        Observer.pauseSound += PauseSound;
    }

    private void OnDisable()
    {
        Observer.playSound -= PlaySound;
        Observer.pauseSound -= PauseSound;
    }

    public void PlaySound(string sound)
    {
        playerAudio.pitch = 1; //Changes pitch back to default before any sound is played
        gunAudio.pitch = 1;
        switch (sound)
        {
            case "Gun":
                gunAudio.pitch = Random.Range(0.7f, 1f); //Changes pitch of gun sounds slightly so its less monotonous
                gunAudio.PlayOneShot(gunShot);
                break;
            case "PlayerDamaged":
                playerAudio.PlayOneShot(playerDMGed); break;
            case "Button":
                playerAudio.pitch = Random.Range(0.9f, 1f); //Changes pitch of gun sounds slightly so its less monotonous
                playerAudio.PlayOneShot(buttonPressed);
                break;
            case "ItemPickedUp":
                playerAudio.PlayOneShot(itemPickedUp); break;
            case "LevelComplete":
                playerAudio.PlayOneShot(levelComplete); break;
            case "Command":
                gunAudio.pitch = Random.Range(0.8f, 1f);
                gunAudio.PlayOneShot(command);
                break;
            case "Typing":
                globalAudio.PlayOneShot(typing);
                break;
        }
    }

    private void PauseSound(string sound)
    {
        switch (sound)
        {
            case "Typing":
                globalAudio.Stop();
                break;
        }
    }

}
