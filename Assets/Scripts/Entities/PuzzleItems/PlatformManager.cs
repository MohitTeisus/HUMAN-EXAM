using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    //Controls all associated Platforms
    [SerializeField] private Platform[] platforms;

    public void ToggleAllPlatform()
    {
        foreach (Platform platform in platforms)
        {
            platform.TogglePlatform();
        }
    }

    public void DisableAllPlatforms()
    {
        foreach (Platform platform in platforms)
        {
            platform.DisablePlatform();
        }
    }

    public void EnableAllPlatforms()
    {
        foreach(Platform platform in platforms)
        {
            platform.EnablePlatform();
        }
    }
}
