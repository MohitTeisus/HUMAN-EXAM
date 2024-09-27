using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NumberButton : MonoBehaviour, ISelectable
{
    [SerializeField]float value;
    [HideInInspector] public float currentValue;
    [SerializeField] NumberPuzzleManager manager;

    [Header("Visuals")]
    public MeshRenderer meshRenderer;
    public Material addMat, subMat, disabledMat;
    [SerializeField] private TextMeshPro valueText;

    NumberState currentState;

    public void OnHoverEnter()
    {
        
    }

    public void OnHoverExit()
    {
        
    }

    public void OnSelect()
    {  
        float sum = currentState.CompleteEquation();
        if (sum == 0) return;
        currentValue = sum;
        manager.processEquation?.Invoke(currentValue);
    }

    public void UpdateCurrentValue(float newValue)
    {
        currentValue = newValue;
    }

    public void ExitCurrentState()
    {
        currentState.OnStateExit();
    }

    public void ChangeState(NumberState newState)
    {
        currentState = newState;
        currentState.OnStateEnter();
    }

    public void DisableButton(float _currentValue)
    {
        currentState = new NumberDisabledState(value, _currentValue, this);
        currentState.OnStateEnter();
    }

    public void ResetButton()
    {
        valueText.text = value.ToString();
        currentValue = 0;
        currentState = new NumberAddState(value, currentValue, this);
        currentState.OnStateEnter();
    }
}
