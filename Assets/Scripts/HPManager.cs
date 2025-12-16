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
        SetTextValues();
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
        SetTextValues();
    }

    public void SetHP(float value)
    {
        healthPoints = value;
    }

    public void SetShield(float value)
    {
        shieldPoints = value;
    }

    private void SetTextValues()
    {
        hp.text = healthPoints.ToString("F0");
        shield.text = shieldPoints.ToString("F0");
    }

    public void Register()
    {
        if (isPlayer)
        {
            GameController.Instance.RegisterPlayerHP(this);
        }
        else
        {
            GameController.Instance.RegisterEnemyHP(this);
        }
    }
}
