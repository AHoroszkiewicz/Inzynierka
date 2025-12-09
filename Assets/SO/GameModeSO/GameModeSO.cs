using UnityEngine;

[CreateAssetMenu(fileName = "GameModeSO", menuName = "Scriptable Objects/GameModeSO")]
public class GameModeSO : ScriptableObject
{
    public string modeName;
    public float playerHP;
    public float enemyHP;
}
