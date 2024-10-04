using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NumberAddState : NumberState
{
    private float sum;

    public NumberAddState(float value, float currentValue, NumberButton numberButton) : base(value, currentValue, numberButton)
    {
    }

    public override float CompleteEquation()
    {
        sum = currentFullValue + buttonValue;
        numberButton.DisableButton();
        return sum;
    }

    public override void OnStateEnter()
    {
        numberButton.meshRenderer.material = numberButton.addMat;
    }

    public override void OnStateExit()
    {
        numberButton.ChangeState((new NumberSubState(buttonValue, numberButton.currentValue, numberButton)));
    }

    public override void OnStateUpdate()
    {
        
    }
}
