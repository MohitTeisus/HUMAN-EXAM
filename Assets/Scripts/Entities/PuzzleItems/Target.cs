using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Events;

public class Target : MonoBehaviour, IShootable
{
    [SerializeField] private MeshRenderer mRenderer;
    [SerializeField] private Material defaultMaterial, hitMaterial;
    private bool isHit;
    private float timer;

    public UnityEvent OnTargetHit;

    void Update()
    {
        if (timer > 0)
        {
            mRenderer.material = hitMaterial;
            timer -= Time.deltaTime;
        }
        else
        {
            isHit = false;
            mRenderer.material = defaultMaterial;
        }
    }

    public void OnHit()
    {    
        if (!isHit)
        {
            isHit = true;
            timer = 0.5f;

            OnTargetHit?.Invoke();
        }
    }
}
