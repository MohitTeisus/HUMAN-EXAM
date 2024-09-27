using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class NumberPuzzleManager : MonoBehaviour
{
    [Header("Visuals")]
    [SerializeField] TextMeshPro solutionText;
    [SerializeField] TextMeshPro currentValueText;

    [Header("Puzzle Variables")]
    [SerializeField] private float minSolution;
    [SerializeField] private float maxSolution;
    private float solution;
    public float currentValue;

    private bool isSolved;

    [SerializeField] private NumberButton[] numberButtons;

    public Action<float> processEquation;
    public UnityEvent puzzleComplete;

    private void OnEnable()
    {
        ResetPuzzle();

        processEquation += ProcessEquation;
    }

    private void OnDisable()
    {
        processEquation -= ProcessEquation;
    }

    private void ProcessEquation(float value)
    {
        currentValue = value;
        if(currentValue < 0 ) currentValue = 0;

        currentValueText.text = currentValue.ToString();

        if (currentValue == solution)
        {
            isSolved = true;
            DisableAllButtons();
            puzzleComplete?.Invoke();
        }
        else
        {
            ChangeButtonStates();
        }
        Debug.Log("current value = " + currentValue);
    }

    private void ChangeButtonStates()
    {
        foreach(NumberButton button in numberButtons)
        {
            button.UpdateCurrentValue(currentValue);
            button.ExitCurrentState();
        }
    }

    private void DisableAllButtons()
    {
        foreach (NumberButton button in numberButtons)
        {
            button.DisableButton(currentValue);
        }
    }

    public void ResetPuzzle()
    {
        currentValue = 0;
        solution = Mathf.RoundToInt(UnityEngine.Random.Range(minSolution, maxSolution));
        currentValueText.text = currentValue.ToString();
        solutionText.text = solution.ToString();

        foreach (NumberButton button in numberButtons)
        {
            button.ResetButton();
        }
    }
}
