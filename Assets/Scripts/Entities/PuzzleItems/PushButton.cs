using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PushButton : MonoBehaviour, ISelectable
{
    [SerializeField] private Material defaultColour, hoverColour, disabledColour;
    [SerializeField] private MeshRenderer buttonRenderer;

    private bool isActive = true;
    public UnityEvent onPush;

    public void OnHoverEnter()
    {
        if (!isActive) return;
        buttonRenderer.material = hoverColour;
    }

    public void OnHoverExit()
    {
        if (!isActive) return;
        buttonRenderer.material = defaultColour;
    }

    public void OnSelect()
    {
        if (!isActive) return;
        Observer.playSound("Button");
        onPush?.Invoke();
    }

    public void DisableButton()
    {
        isActive = false;
        buttonRenderer.material = disabledColour;
    }

    public void EnableButton()
    {
        isActive = true;
        buttonRenderer.material = defaultColour;
    }
}
