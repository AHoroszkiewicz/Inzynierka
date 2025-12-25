using Unity.VisualScripting;
using UnityEngine;

public enum SoundType
{
    BackgroundMusic = 0,
    ButtonClick = 1,
    CardPlay = 2,
    Attack = 3,
    DamageTaken = 4,
    Heal = 5,
    ShieldUp = 6,
    GameOver = 7
}

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioClip[] soundClips;
    private AudioSource audioSource;
    private float volume = 1.0f;

    public float Volume
    {
        get => volume;
        set
        {
            volume = Mathf.Clamp01(value);
            audioSource.volume = volume;
        }
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySound(SoundType soundType)
    {
        audioSource.PlayOneShot(soundClips[(int)soundType], volume);
        Debug.Log($"Playing sound: {soundType}");
    }
}
