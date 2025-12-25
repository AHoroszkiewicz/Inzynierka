using System;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    [SerializeField] private List<CardDataSO> cardDataList = new List<CardDataSO>();
    [SerializeField] private GameObject cardPrefab;
    [SerializeField] private Transform cardParent;
    [SerializeField] private EquationManager equationManager;
    [SerializeField] private Transform cardDragParent;
    [SerializeField] private Canvas canvas;
    [SerializeField] private int cardNumber = 5;

    private List<Card> currentHand = new List<Card>();
    private string currentExpression = "";

    private void Awake()
    {
        GameManager.Instance.RegisterCardManager(this);
    }

    private void Start()
    {
        DrawCards(); // Dobieramy karty na start
    }

    public void DrawCards(int numberOfCards)
    {
        for (int i = 0; i < numberOfCards; i++)
        {
            CardDataSO randomCard = cardDataList[UnityEngine.Random.Range(0, cardDataList.Count)];
            GameObject newCardObj = Instantiate(cardPrefab, cardParent);
            Card newCard = newCardObj.GetComponent<Card>();
            newCard.Initialize(randomCard, this, cardDragParent, canvas);
            currentHand.Add(newCard);
        }
    }

    public void DrawCards()
    {
        DrawCards(cardNumber);
    }

    public void ClearHand()
    {
        foreach (Card card in currentHand)
        {
            Destroy(card.gameObject);
        }
        currentHand.Clear();
    }

    public void UseCard(Card card)
    {
        equationManager.AddToEquation(card.Value);
        GameManager.Instance.AddCardEffect(card);
    }

    public void EvaluateExpression()
    {
        try
        {
            double result = Evaluate(currentExpression);
            Debug.Log("Result: " + result);
        }
        catch (Exception e)
        {
            Debug.Log("Invalid expression: " + e.Message);
        }
    }

    private double Evaluate(string expression)
    {
        return (double)new System.Data.DataTable().Compute(expression, null);
    }
}
