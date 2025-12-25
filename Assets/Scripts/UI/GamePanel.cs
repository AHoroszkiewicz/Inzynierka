using System.Collections.Generic;
using UnityEngine;

public class GamePanel : UIPanel
{
    [SerializeField] private List<GameModeSO> gameModes = new List<GameModeSO>();
    [SerializeField] private GameObject buttonPrefab;
    [SerializeField] private Transform buttonContainer;

    override public void Initialize(MainMenuController controller)
    {
        CreateButtons();
        base.Initialize(controller);
    }

    private void CreateButtons()
    {
        foreach (var gameMode in gameModes)
        {
            var buttonObject = Instantiate(buttonPrefab, buttonContainer);
            var uiButton = buttonObject.GetComponent<UIButton>();
            uiButton.SetLabel(gameMode.modeName);
            Buttons.Add(uiButton);

            GameModeSO mode = gameMode;

            uiButton.Button.onClick.AddListener(() =>
            {
                GameManager.Instance.SetGameMode(mode);
            });
        }
    }

}
