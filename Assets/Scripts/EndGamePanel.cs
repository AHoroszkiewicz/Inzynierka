using TMPro;
using UnityEngine;

public class EndGamePanel : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] private TextMeshProUGUI WinTxt;
    [SerializeField] private CanvasGroup canvasGroup;

    private void Awake()
    {
        GameManager.Instance.RegisterEndGamePanel(this);
    }

    public void ShowEndGamePanel(bool playerWon)
    {
        canvasGroup.alpha = 1;
        canvasGroup.blocksRaycasts = true;
        canvasGroup.interactable = true;
        WinTxt.text = playerWon ? "Wygrana!" : "Przegrana!";
    }
}
