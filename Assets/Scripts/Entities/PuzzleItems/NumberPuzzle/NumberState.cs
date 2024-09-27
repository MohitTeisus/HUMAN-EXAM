using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class NumberState : BaseState
{
    protected float buttonValue;
    protected float currentFullValue;
    protected NumberButton numberButton;

    public NumberState(float value, float currentValue, NumberButton numberButton)
    {
        this.buttonValue = value;
        this.currentFullValue = currentValue;
        this.numberButton = numberButton;
    }

    public abstract float CompleteEquation();
}
