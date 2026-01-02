using System;
using System.Collections.Generic;
using System.Linq;
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
    [SerializeField] private int maxCards = 6;
    [SerializeField] private int minNumberCards = 2;
    [SerializeField] private int minSymbolCards = 2;

    private List<Card> currentHand = new List<Card>();
    private string currentExpression = "";
    private int numberOfNumberCards;
    private int numberOfSymbolCards;
    private List<CardDataSO> numberCards;
    private List<CardDataSO> symbolCards;

    private void Awake()
    {
        GameManager.Instance.RegisterCardManager(this);
    }

    private void Start()
    {
        numberCards = cardDataList.Where(c => c.type == CardType.Number).ToList();
        symbolCards = cardDataList.Where(c => c.type != CardType.Number).ToList();
        DrawCards(); // Dobieramy karty na start
    }

    public void DrawCards(int numberOfCards)
    {
        if (numberOfCards > maxCards)
        {
            numberOfCards = maxCards;
        }

        for (int i = 0; i < minNumberCards; i++)
        {
            DrawRandomFrom(numberCards);
        }

        for (int i = 0; i < minSymbolCards; i++)
        {
            DrawRandomFrom(symbolCards);
        }

        int remaining = numberOfCards - minNumberCards - minSymbolCards;
        for (int i = 0; i < remaining; i++)
        {
            DrawRandomFrom(cardDataList);
        }
    }

    private void DrawRandomFrom(List<CardDataSO> source)
    {
        CardDataSO randomCard = source[UnityEngine.Random.Range(0, source.Count)];
        GameObject newCardObj = Instantiate(cardPrefab, cardParent);
        Card newCard = newCardObj.GetComponent<Card>();
        newCard.Initialize(randomCard, this, cardDragParent, canvas);
        currentHand.Add(newCard);
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
