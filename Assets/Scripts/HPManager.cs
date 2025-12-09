using TMPro;
using UnityEngine;

public class HPManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI hp;
    [SerializeField] private float healthPoints = 100f;

    public float HealthPoints => healthPoints;

    private void Awake()
    {
        Register();
    }

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

    public void SetHP(float value)
    {
        healthPoints = value;
    }

    virtual public void Register()
    {
        // To be overridden in derived classes
    }
}
