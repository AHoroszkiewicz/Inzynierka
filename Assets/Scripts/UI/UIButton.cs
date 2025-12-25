using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIButton : MonoBehaviour, ISelectHandler, IPointerEnterHandler
{
    [SerializeField] Button button;

    private UIPanel panel;
    private int buttonId;

    public Button Button => button;

    public void Initialize(UIPanel uiPanel, int id)
    {
        panel = uiPanel;
        buttonId = id;
    }

    public void OnSelect(BaseEventData eventData)
    {
        if (panel == null)
        {
            Debug.LogWarning("UIButton OnSelect called before initialization.");
            return;
        }
        panel.SelectedButtonId = buttonId;
        panel.SelectedButton = button;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        EventSystem.current.SetSelectedGameObject(gameObject);
        OnSelect(null);
    }

    public void SetLabel(string label)
    {
        var textComponent = button.GetComponentInChildren<TextMeshProUGUI>();
        if (textComponent != null)
        {
            textComponent.text = label;
        }
    }

    public void PlayClickSound()
    {
        GameManager.Instance.SoundManager.PlaySound(SoundType.ButtonClick);
    }
}
