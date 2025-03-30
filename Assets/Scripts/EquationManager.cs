using System;
using TMPro;
using UnityEngine;

public class EquationManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI equationText;

    private string equation;
    private double result;

    public void AddToEquation(string value)
    {
        equation += value;
        EvaluateExpression();
        equationText.text = equation + " = " + result.ToString();
    }

    private void EvaluateExpression()
    {
        try
        {
            result = Evaluate(equation);
            Debug.Log("Result: " + result);
        }
        catch (Exception e)
        {
            result = 0;
            Debug.Log("Invalid expression: " + e.Message);
        }
    }

    private double Evaluate(string expression)
    {
        object result = new System.Data.DataTable().Compute(expression, null);
        return Convert.ToDouble(result);
    }
}
