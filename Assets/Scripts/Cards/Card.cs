using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    [SerializeField] private CardDataSO cardData;
    [SerializeField] private Image cardImage;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private bool use;

    private Sprite sprite;
    private string value;
    private CardManager cardManager;

    public string Value => value;

    private void Update()
    {
        if (use)
        {
            use = false;
            OnClick();
        }
    }

    public void Initialize(CardDataSO card, CardManager manager)
    {
        cardData = card;
        cardManager = manager;
        sprite = cardData.sprite;
        cardImage.sprite = sprite;
        value = cardData.value;
        text.text = value;
    }

    public void OnClick()
    {
        cardManager.AddToExpression(this);
    }
}
