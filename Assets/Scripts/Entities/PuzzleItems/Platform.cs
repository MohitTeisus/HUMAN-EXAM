using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private MeshRenderer[] meshRenderers;
    [SerializeField] private Material defaultMaterial, borderMaterial, invisMaterial;

    [SerializeField] private bool isEnabled;

    // Start is called before the first frame update
    void Start()
    {
        if (isEnabled) EnablePlatform();
        else DisablePlatform();
    }

    public void TogglePlatform()
    {
        isEnabled =  !isEnabled;

        if(isEnabled) EnablePlatform();
        else DisablePlatform();
    }

    public void EnablePlatform()
    {
        foreach (var renderer in meshRenderers)
        {
            renderer.GetComponent<Collider>().enabled = true;
        }
        meshRenderers[0].material = defaultMaterial;
        meshRenderers[1].material = borderMaterial;
    }
    public void DisablePlatform()
    {
        foreach (var renderer in meshRenderers)
        {
            renderer.material = invisMaterial;
            renderer.GetComponent<Collider>().enabled = false;
        }
    }
}
