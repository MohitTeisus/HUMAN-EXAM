using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Indicator : MonoBehaviour
{
    [Header("Indicator")]
    [SerializeField] MeshRenderer meshRenderer;
    [SerializeField] Material activeMaterial, inactiveMaterial;
    [SerializeField] private bool isActive;

    private void Start()
    {
        if (isActive) meshRenderer.material = activeMaterial;
        if (!isActive) meshRenderer.material = inactiveMaterial;
    }

    public void ChangeIndicator()
    {
        isActive = !isActive;

        if (isActive == true) meshRenderer.material = activeMaterial;
        if (isActive == false) meshRenderer.material = inactiveMaterial;
    }

    public void ChangeIndicator(bool changeStatus)
    {
        isActive = changeStatus;

        if (isActive == true) meshRenderer.material = activeMaterial;
        if (isActive == false) meshRenderer.material = inactiveMaterial;
    }

    public bool GetStatus()
    {
        return isActive;
    }
}
