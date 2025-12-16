using System.Collections;
using UnityEngine;

public class DrawCardsEffect : ICardEffect
{
    private int numberOfCards;

    public DrawCardsEffect(int numberOfCards)
    {
        this.numberOfCards = numberOfCards;
    }

    public IEnumerator Execute(GameController gameController)
    {
        gameController.CardManager.DrawCards(numberOfCards);
        yield return null;
    }
}
