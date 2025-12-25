using TMPro;
using UnityEngine;

public class HPManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI hp;
    [SerializeField] private float healthPoints = 100f;
    [SerializeField] private TextMeshProUGUI shield;
    [SerializeField] private float shieldPoints = 10f;
    [SerializeField] private bool isPlayer;

    public float HealthPoints => healthPoints;

    private void Awake()
    {
        Register();
    }

    private void Start()
    {
        UpdateTextValues();
    }

    public void TakeDamage(float damage)
    {
        if (shieldPoints > 0)
        {
            float shieldAbsorb = Mathf.Min(shieldPoints, damage);
            shieldPoints -= shieldAbsorb;
            damage -= shieldAbsorb;
        }
        healthPoints -= damage;
        if (healthPoints < 0) healthPoints = 0;
        UpdateTextValues();
    }

    public void SetHP(float value)
    {
        healthPoints = value;
        UpdateTextValues();
    }

    public void AddHP(float value)
    {
        healthPoints += value;
        UpdateTextValues();
    }

    public void SetShield(float value)
    {
        shieldPoints = value;
        UpdateTextValues();
    }

    public void AddShield(float value)
    {
        shieldPoints += value;
        UpdateTextValues();
    }

    private void UpdateTextValues()
    {
        hp.text = healthPoints.ToString("F0");
        shield.text = shieldPoints.ToString("F0");
    }

    public void Register()
    {
        if (isPlayer)
        {
            GameManager.Instance.RegisterPlayerHP(this);
        }
        else
        {
            GameManager.Instance.RegisterEnemyHP(this);
        }
    }
}
