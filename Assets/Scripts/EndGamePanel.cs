using TMPro;
using UnityEngine;

public class EndGamePanel : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] private TextMeshProUGUI WinTxt;

    public void ShowEndGamePanel(bool playerWon)
    {
        panel.SetActive(true);
        WinTxt.text = playerWon ? "Wygrana!" : "Przegrana!";
    }
}
