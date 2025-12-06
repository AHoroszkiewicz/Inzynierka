using UnityEngine;

public class TurnManager : MonoBehaviour
{
    [SerializeField] private HPManager playerHPManager;
    [SerializeField] private HPManager enemyHPManager;
    [SerializeField] private EndGamePanel endGamePanel;

    private int turnCounter = 0;
    private bool isPlayerTurn = true;
    private bool isGameOver = false;

    public void EndTurn()
    {
        if (isGameOver) return;
        turnCounter++;
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
            EndTurn();
        }
    }
}
