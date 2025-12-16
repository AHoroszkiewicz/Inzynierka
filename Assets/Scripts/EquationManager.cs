using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class EquationManager : MonoBehaviour, IDropHandler
{
    [SerializeField] private TextMeshProUGUI equationText;
    
    private GameController gameController => GameController.Instance;
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

    private void ClearEquation()
    {
        equation = "";
        result = 0;
        equationText.text = equation + " = " + result.ToString();
    }

    public void OnDrop(PointerEventData eventData)
    {
        eventData.pointerDrag?.GetComponent<Card>()?.OnClick();
    }

    public void DealDMG()
    {
        gameController.EndTurn((float)result);
        ClearEquation();
    }
}
