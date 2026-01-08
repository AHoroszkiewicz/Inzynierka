using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EquationManager : MonoBehaviour, IDropHandler
{
    [SerializeField] private TextMeshProUGUI equationText;
    [SerializeField] private Image TxtImage;
    [SerializeField] private TextMeshProUGUI resultText;
    
    private GameManager gameController => GameManager.Instance;
    private string equation;
    private double result;
    private bool previousCardWasNumber = false;

    public void AddToEquation(string value)
    {
        TxtImage.enabled = false;
        equation += value;
        EvaluateExpression();
        equationText.text = equation;
        resultText.text = result.ToString();
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
        equationText.text = equation + "";
        resultText.text = "";
        TxtImage.enabled = true;
    }

    public void OnDrop(PointerEventData eventData)
    {
        Card card = eventData.pointerDrag?.GetComponent<Card>();
        if (card == null || (previousCardWasNumber && card.Type == CardType.Number) || (!previousCardWasNumber && card.Type != CardType.Number))
            return;
        previousCardWasNumber = !previousCardWasNumber;
        card.OnClick();
    }

    public void DealDMG()
    {
        gameController.EndTurn((float)result);
        ClearEquation();
    }
}
