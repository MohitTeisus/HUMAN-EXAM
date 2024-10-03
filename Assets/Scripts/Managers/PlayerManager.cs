using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    //Singleton
    public static PlayerManager instance;
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(instance);
            return;
        }
        instance = this;
    }

    [SerializeField] private Transform player;
    [SerializeField] private Transform checkpoint;
    [SerializeField] private Transform spawnpoint;

    public void SetCheckpoint(Transform newCheckpoint)
    {
        checkpoint = newCheckpoint;
    }

    public void ReturnToCheckpoint()
    {
        //Must disable character controller before adjusting position of player
        player.GetComponent<CharacterController>().enabled = false;
        player.position = checkpoint.position;
        player.GetComponent<CharacterController>().enabled = true;
        Observer.spawnPlayer?.Invoke();
    }

    public void ReturnToSpawn()
    {
        player.GetComponent<CharacterController>().enabled = false;
        player.position = spawnpoint.position;
        player.GetComponent<CharacterController>().enabled = true;
        Observer.spawnPlayer?.Invoke();
    }
}
