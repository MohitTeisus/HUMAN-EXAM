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

    private void OnEnable()
    {
        Observer.onDeath += PlayerDeath;
    }

    private void OnDisable()
    {
        Observer.onDeath -= PlayerDeath;
    }

    public void SetCheckpoint(Transform newCheckpoint)
    {
        checkpoint = newCheckpoint;
    }

    public void ReturnToCheckpoint()
    {
        //Must disable character controller before adjusting position of player
        PlayerRespawn();
        player.GetComponent<CharacterController>().enabled = false;
        player.position = checkpoint.position;
        player.GetComponent<CharacterController>().enabled = true;
        Observer.spawnPlayer();
    }

    private void PlayerDeath()
    {
        player.gameObject.SetActive(false);
    }

    private void PlayerRespawn()
    {
        player.gameObject.SetActive(true);
    }

    public void ReturnToSpawn()
    {
        PlayerRespawn();
        player.GetComponent<CharacterController>().enabled = false;
        player.position = spawnpoint.position;
        player.GetComponent<CharacterController>().enabled = true;
        Observer.spawnPlayer();
    }
}
