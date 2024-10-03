using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Observer
{
    public static Action onShoot;

    public static Action onDeath;
    public static Action<float> onPlayerHit;

    public static Action<bool> onInteractHover;
    public static Action onInteract;

    public static Action<bool> onPickupHover;
    public static Action onPickup;

    public static Action<bool> onPause;

    public static Action<string> playSound;

    public static Action spawnPlayer;
}
