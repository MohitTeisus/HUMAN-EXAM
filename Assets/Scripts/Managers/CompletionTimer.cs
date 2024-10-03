using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class CompletionTimer : MonoBehaviour
{
    private bool timerStarted;
    private float completionTimer;

    // Update is called once per frame
    void Update()
    {
        if (timerStarted)
        {
            completionTimer += Time.deltaTime;
        }
    }

    public void StartTimer()
    {
        timerStarted = true;
    }

    public void EndTimer()
    {
        timerStarted = false;
        Observer.completionTime(completionTimer);
    }
}
