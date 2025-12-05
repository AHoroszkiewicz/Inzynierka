using TMPro;
using UnityEngine;

public class HPManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI hp;
    [SerializeField] private float healthPoints = 100f;

    private void Start()
    {
        hp.text = healthPoints.ToString("F0");
    }

    public void TakeDamage(float damage)
    {
        healthPoints -= damage;
        if (healthPoints < 0) healthPoints = 0;
        hp.text = healthPoints.ToString("F0");
    }
}
