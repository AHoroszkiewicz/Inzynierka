using UnityEngine;

public enum CardType
{
    None = 0,
    Number = 1,
    Operator = 2,
    Parenthesis = 3
}

[CreateAssetMenu(fileName = "CardData", menuName = "Scriptable Objects/CardData")]
public class CardDataSO : ScriptableObject
{
    public CardType type;
    public Sprite sprite;
    public string value;
}
