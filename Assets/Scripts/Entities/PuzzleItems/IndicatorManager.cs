using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class IndicatorManager : MonoBehaviour
{
    [SerializeField] private Indicator[] indicators;
    public UnityEvent AllIndicatorsActive;


    public void CheckIndicators()
    {
        int counter = 0;
        for (int i = 0; i < indicators.Length; i++)
        {
            if(indicators[i].GetStatus() == true)
            {
                counter++;
            }
            else
            {
                break;
            }
        }

        if(counter == indicators.Length)
        {
            Debug.Log("AllIndicatorActive");
            AllIndicatorsActive?.Invoke();
        }
    }
}
