using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CosmeticIndicatorManager : MonoBehaviour
{
    //Used to change multiple indicators at once, specifically for props like the pipes
    //and door indicators
    [SerializeField] private Indicator[] indicators;

    public void UpdateAllIndicators()
    {
        foreach (var indicator in indicators)
        {
            indicator.ChangeIndicator();
        }
    }

    public void UpdateAllIndicators(bool activity)
    {
        foreach(var indicator in indicators)
        {
            indicator.ChangeIndicator(activity);
        }
    }
}
