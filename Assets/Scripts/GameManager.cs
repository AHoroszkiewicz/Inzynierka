using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Collections;

public class GameManager : MonoBehaviour
{
    [SerializeField] private HPManager playerHPManager;
    [SerializeField] private HPManager enemyHPManager;
    [SerializeField] private EndGamePanel endGamePanel;
    [SerializeField] private CardManager cardManager;
    [SerializeField] private int cardsOnSubtraction = 2;
    [SerializeField] private int shieldOnDivision = 10;
    [SerializeField] private int cardsOnPower = 1;
    [SerializeField] private SoundManager soundManager;

    private int turnCounter = 0;
    private bool isPlayerTurn = true;
    private bool isGameOver = false;
    private GameModeSO currentGameMode;
    private Queue<ICardEffect> effectQueue = new Queue<ICardEffect>();

    public static GameManager Instance;
    public GameModeSO CurrentGameMode => Instance.currentGameMode;
    public CardManager CardManager => Instance.cardManager;
    public SoundManager SoundManager => Instance.soundManager;

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

    private void Update()
    {
        if (isGameOver && Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(2))
        { 
            EndGame();
        }
    }

    public void RegisterPlayerHP(HPManager hpManager)
    {
        playerHPManager = hpManager;
        playerHPManager.SetHP(currentGameMode.playerHP);
        playerHPManager.SetShield(currentGameMode.playerShield);
    }

    public void RegisterEnemyHP(HPManager hpManager)
    {
        enemyHPManager = hpManager;
        enemyHPManager.SetHP(currentGameMode.enemyHP);
        enemyHPManager.SetShield(currentGameMode.enemyShield);
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
            StartCoroutine(ProcessEffects());
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

    public void EndGame()
    {
        isPlayerTurn = true;
        isGameOver = false;
        SceneManager.LoadScene(0);
    }

    public void SetGameMode(GameModeSO mode)
    {
        currentGameMode = mode;
        StartGame();
    }

    public void AddCardEffect(Card card)
    {
        switch (card.Type)
        {
            case CardType.Subtraction:
                effectQueue.Enqueue(new DrawCardsEffect(cardsOnSubtraction));
                break;
            case CardType.Division:
                effectQueue.Enqueue(new AddShieldEffect(shieldOnDivision));
                break;
            case CardType.Power:
                effectQueue.Enqueue(new DrawCardsEffect(cardsOnPower));
                break;
        }
    }

    private IEnumerator ProcessEffects()
    {
        while (effectQueue.Count > 0)
        {
            ICardEffect effect = effectQueue.Dequeue();
            yield return StartCoroutine(effect.Execute(this));
        }
    }

    public void AddPlayerShield(int value)
    {
        playerHPManager.AddShield(value);
        Debug.Log("Added " + value + " shield to player.");
    }
}
