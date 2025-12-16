using UnityEngine;

public enum CardType
{
    None = 0,
    Number = 1,
    Addition = 2,
    Subtraction = 3,
    Multiplication = 4,
    Division = 5,
    Power = 6,
    SquareRoot = 7,
    parenthesis = 8,
}

[CreateAssetMenu(fileName = "CardData", menuName = "Scriptable Objects/CardData")]
public class CardDataSO : ScriptableObject
{
    public CardType type;
    public Sprite sprite;
    public string value;
}
