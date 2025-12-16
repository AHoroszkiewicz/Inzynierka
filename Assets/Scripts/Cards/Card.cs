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
    private DraggableItem draggableItem;
    private CardType type;

    public string Value => value;
    public CardType Type => type;

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
