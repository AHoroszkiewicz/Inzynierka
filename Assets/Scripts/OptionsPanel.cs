using TMPro;
using UnityEngine;

public class OptionsPanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI volumeValue;

    public void ChangeVolume(float value)
    {
        volumeValue.text = Mathf.RoundToInt(value * 100).ToString();
        GameManager.Instance.SoundManager.Volume = value;
    }
}
