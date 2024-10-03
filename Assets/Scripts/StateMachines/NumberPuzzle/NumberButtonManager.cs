using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberButtonManager : MonoBehaviour
{
    private float currentValue;
    [SerializeField] private NumberButton[] numberButtons;

    public void ChangeButtonStates()
    {
        foreach (NumberButton button in numberButtons)
        {
            button.UpdateCurrentValue(currentValue);
            button.ExitCurrentState();
        }
    }

    public void DisableAllButtons()
    {
        foreach (NumberButton button in numberButtons)
        {
            button.DisableButton();
        }
    }

    public void ResetButtons()
    { 

        foreach (NumberButton button in numberButtons)
        {
            button.ResetButton();
        }
    }

    public void UpdateCurrentValue(float value)
    {
        currentValue = value;
    }
}
