using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactor : MonoBehaviour
{
    protected PlayerInput input;

    public abstract void Interact();

    private void Start()
    {
        input = PlayerInput.GetInstance();
    }

    private void Update()
    {
        Interact();
    }
}
