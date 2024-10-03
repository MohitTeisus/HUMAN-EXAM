using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberDisabledState : NumberState
{
    public NumberDisabledState(float value, float currentValue, NumberButton numberButton) : base(value, currentValue, numberButton)
    {

    }

    public override float CompleteEquation()
    {
        return 0;
    }

    public override void OnStateEnter()
    {
        Debug.Log("Entering Disabled State");
        numberButton.meshRenderer.material = numberButton.disabledMat;
    }

    public override void OnStateExit()
    {

    }

    public override void OnStateUpdate()
    {

    }

    
}
