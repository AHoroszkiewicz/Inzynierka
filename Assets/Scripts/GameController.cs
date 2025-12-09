using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] private HPManager playerHPManager;
    [SerializeField] private HPManager enemyHPManager;
    [SerializeField] private EndGamePanel endGamePanel;
    [SerializeField] private CardManager cardManager;

    private int turnCounter = 0;
    private bool isPlayerTurn = true;
    private bool isGameOver = false;
    private GameModeSO currentGameMode;

    public static GameController Instance;
    public GameModeSO CurrentGameMode => Instance.currentGameMode;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void RegisterPlayerHP(HPManager hpManager)
    {
        playerHPManager = hpManager;
        playerHPManager.SetHP(currentGameMode.playerHP);
    }

    public void RegisterEnemyHP(HPManager hpManager)
    {
        enemyHPManager = hpManager;
        enemyHPManager.SetHP(currentGameMode.enemyHP);
    }

    public void RegisterEndGamePanel(EndGamePanel panel)
    {
        endGamePanel = panel;
    }

    public void RegisterCardManager(CardManager manager)
    {
        cardManager = manager;
    }

    public void DealDMG(float damage)
    {
        enemyHPManager.TakeDamage(damage);
    }

    public void EndTurn(float damage)
    {
        if (isGameOver) return;
        turnCounter++;
        if (isPlayerTurn)
        {
            cardManager.ClearHand();
            cardManager.DrawCards();
            DealDMG(damage);
        }        
        isPlayerTurn = !isPlayerTurn;
        if (enemyHPManager.HealthPoints <= 0)
        {
            endGamePanel.ShowEndGamePanel(true);
            isGameOver = true;
            return;
        }
        if (!isPlayerTurn)
        {
            int random = Random.Range(0, 10);
            playerHPManager.TakeDamage(random);
            if (playerHPManager.HealthPoints <= 0)
            {
                endGamePanel.ShowEndGamePanel(false);
                isGameOver = true;
                return;
            }
            EndTurn(0);
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    internal void SetGameMode(GameModeSO mode)
    {
        currentGameMode = mode;
        StartGame();
    }
}
