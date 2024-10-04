using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunAnimation : MonoBehaviour
{
    [SerializeField] Animator animator;

    private void OnEnable()
    {
        Observer.onShoot += ShootAnimation;
    }

    private void OnDisable()
    {
        Observer.onShoot -= ShootAnimation;
    }

    void ShootAnimation()
    {
        animator.SetTrigger("GunShot");
    }
}
