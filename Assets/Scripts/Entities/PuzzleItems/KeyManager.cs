using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KeyManager : MonoBehaviour
{
    private int keysCollected;
    [SerializeField] private int keysRequired;

    public UnityEvent onKeysCollected;

    public void KeyCollected()
    {
        keysCollected++;
        CheckKeys();
    }

    private void CheckKeys()
    {
        if(keysCollected == keysRequired)
        {
            onKeysCollected?.Invoke();
        }
    }
}
