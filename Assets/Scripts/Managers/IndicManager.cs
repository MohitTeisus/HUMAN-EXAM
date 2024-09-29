using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndicManager : MonoBehaviour
{
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
