using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    [SerializeField] private CardDataSO cardData;
    [SerializeField] private Image cardImage;
    [SerializeField] private Image effectImage;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private bool use;

    private Sprite sprite;
    private Sprite effectSprite;
    private string value;
    private CardManager cardManager;
    private DraggableItem draggableItem;
    private CardType type;
    private CardEffectType effectType;
    private int effectValue;

    public string Value => value;
    public CardType Type => type;
    public CardEffectType EffectType => effectType;
    public int EffectValue => effectValue;

    private void Update()
    {
        if (use)
        {
            use = false;
            OnClick();
        }
    }

    public void Initialize(CardDataSO card, CardManager manager, Transform dragParent = null, Canvas dragCanvas = null)
    {
        cardData = card;
        cardManager = manager;
        sprite = cardData.sprite;
        cardImage.sprite = sprite;
        value = cardData.value;
        text.text = value;
        type = cardData.type;
        effectValue = cardData.effectValue;
        effectType = cardData.effectType;
        if (effectType != CardEffectType.None)
        {
            effectSprite = card.effectSprite;
            effectImage.sprite = effectSprite;
            effectImage.gameObject.SetActive(true);
        }
        else
        {
            effectImage.gameObject.SetActive(false);
        }
        if ( draggableItem == null)
            draggableItem = GetComponent<DraggableItem>();
        if (dragParent != null && draggableItem != null && dragCanvas != null)
        {
            draggableItem.newParent = dragParent;
            draggableItem.canvas = dragCanvas;
        }
    }

    public void OnClick()
    {
        cardManager.UseCard(this);
        gameObject.SetActive(false);
    }
}
