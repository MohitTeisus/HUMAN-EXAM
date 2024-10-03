using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(instance);
            return;
        }
        instance = this;
    }

    private PlayerInput input;
    bool isPaused;

    // Start is called before the first frame update
    void Start()
    {
        input = PlayerInput.GetInstance();
    }

    // Update is called once per frame
    void Update()
    {
        if(input.pausePressed)
        {
            PauseGame(!isPaused);
        }
    }

    public void PauseGame(bool paused)
    { 
        isPaused = paused;
        Observer.onPause?.Invoke(isPaused);
        Debug.Log("Paused = " + isPaused);
    }
}
