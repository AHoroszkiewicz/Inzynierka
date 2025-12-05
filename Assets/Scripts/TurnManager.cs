using UnityEngine;

public class TurnManager : MonoBehaviour
{
    [SerializeField] private HPManager playerHPManager;
    [SerializeField] private HPManager enemyHPManager;

    private int turnCounter = 0;
    private bool isPlayerTurn = true;

    public void EndTurn()
    {
        turnCounter++;
        isPlayerTurn = !isPlayerTurn;
        Debug.Log($"Turn {turnCounter}: {(isPlayerTurn ? "Player's" : "Enemy's")} turn.");
        if (!isPlayerTurn)
        {
            int random = Random.Range(0, 10);
            playerHPManager.TakeDamage(random);
            Debug.Log($"Enemy attacks for {random} damage!");
            EndTurn();
        }
    }
}
