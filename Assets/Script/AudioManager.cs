using JetBrains.Annotations;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public AudioSource MainMenuAudio;
    public AudioSource CalmAudio;
    public AudioSource StressAudio;

    void Start()
    {
        MainMenuAudio.Play();
        CalmAudio.Stop();
        StressAudio.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
