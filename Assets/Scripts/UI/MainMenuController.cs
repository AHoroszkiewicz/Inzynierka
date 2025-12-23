using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MainMenuController : MonoBehaviour
{
    [Header("UI Panels")]
    [SerializeField] private UIPanel titlePanel;
    [SerializeField] private UIPanel menuPanel;
    [SerializeField] private UIPanel gamePanel;
    [SerializeField] private UIPanel optionsPanel;

    private List<UIPanel> uIPanels = new List<UIPanel>();
    private UIPanel currentPanel;
    private Stack<UIPanel> panelStack = new Stack<UIPanel>();
    private GameController gameController => GameController.Instance;

    private void Awake()
    {
        titlePanel.Initialize(this);
        uIPanels.Add(titlePanel);
        menuPanel.Initialize(this);
        uIPanels.Add(menuPanel);
        gamePanel.Initialize(this);
        uIPanels.Add(gamePanel);
        optionsPanel.Initialize(this);
        uIPanels.Add(optionsPanel);
    }

    private void Start()
    {
        ActivatePanel(titlePanel);
    }

    private void Update()
    {
        if (currentPanel == titlePanel)
        {
            if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(2))
            {
                OpenMenuPanel();
            }
        }
    }

    public void OpenMenuPanel()
    {
        ActivatePanel(menuPanel);
    }

    public void OpenGamesPanel()
    {
        ActivatePanel(gamePanel);
    }

    public void OpenOptionsPanel()
    {
        ActivatePanel(optionsPanel);
    }

    private void ActivatePanel(UIPanel panel)
    {
        Debug.Log("Activating panel: " + panel.name);
        {
            if (panel == currentPanel) return;
            if (panelStack.Count > 0)
            {
                UIPanel currentPanel = panelStack.Peek();
                currentPanel.Deactivate();
            }

            panel.Activate();
            panelStack.Push(panel);
            currentPanel = panel;
        }
    }

    public void CloseCurrentPanel()
    {
        if (currentPanel == titlePanel || currentPanel == menuPanel) return;
        if (panelStack.Count > 1)
        {
            UIPanel activePanel = panelStack.Pop();
            activePanel.Deactivate();
            UIPanel previousPanel = panelStack.Peek();
            previousPanel.Activate();
            currentPanel = previousPanel;
        }
    }

    public void ClosePanel(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            CloseCurrentPanel();
        }
    }

    public void Submit(InputAction.CallbackContext ctx)
    {      
        if (ctx.performed)
        {
            currentPanel.Submit();
        }
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        gameController.StartGame();
    }
}
