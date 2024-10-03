using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NumberSubState : NumberState
{
    private float dif;
    public NumberSubState(float value, float currentValue, NumberButton numberButton) : base(value, currentValue, numberButton)
    {
    }

    public override float CompleteEquation()
    {
        dif = currentFullValue - buttonValue;
        numberButton.DisableButton();
        return dif;
    }

    public override void OnStateEnter()
    {
        numberButton.meshRenderer.material = numberButton.subMat;
    }

    public override void OnStateExit()
    {
        numberButton.ChangeState((new NumberAddState(buttonValue, numberButton.currentValue, numberButton)));
    }

    public override void OnStateUpdate()
    {
        
    }
}
