using System.Collections;
using UnityEngine;

public class SpeechBubble : MonoBehaviour
{
    [SerializeField] private GameObject[] bubbles;
    [SerializeField] private AudioSource[] sounds;   // same order as bubbles

    [SerializeField] private float waitBetween = 5f;
    [SerializeField] private float showDuration = 2f;

    void Start()
    {
        foreach (var b in bubbles) b.SetActive(false);
        StartCoroutine(SpeechLoop());
    }

    IEnumerator SpeechLoop()
    {
        while (true)
        {
            yield return new WaitForSeconds(waitBetween);

            int n = Random.Range(0, bubbles.Length);   // picked once per speech

            bubbles[n].SetActive(true);
            if (n < sounds.Length && sounds[n] != null)
                sounds[n].Play();

            yield return new WaitForSeconds(showDuration);

            bubbles[n].SetActive(false);
        }
    }
}