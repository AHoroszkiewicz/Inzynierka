using UnityEngine;
using UnityEngine.EventSystems;

public class DraggableItem : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public Transform newParent;
    public Canvas canvas;
    private Transform originalParent;
    private Vector3 originalPosition;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (eventData.pointerEnter != null)
        {
            canvasGroup.blocksRaycasts = false;
            originalParent = transform.parent;
            originalPosition = transform.position;
            if (newParent != null)
                transform.SetParent(newParent);
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;
        if (transform.parent == newParent || eventData.pointerEnter == null)
        {
            transform.SetParent(originalParent);
            transform.position = originalPosition;
        }
    }
}
