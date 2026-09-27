using System.Collections;
using UnityEngine;

public class CardFlip : MonoBehaviour
{
    private bool isHovering;
    private CardIdentity identity;
    public DeckTesting deckTesting;
    public GameObject cardBackPrefab;
    public float flipDelay = 0.3f;
    public bool isFlipping = false;
    public float flipDuration = 0.3f;

    // Start is called once before the first execution of Update after the MonoBehaviour=

    // Update is called once per frame
    void Update()
    {
        if (isHovering && Input.GetKeyDown(KeyCode.K))
        {
            StartCoroutine(FlipRoutine());
        }
    }
    void OnMouseEnter()
    {
        isHovering = true;
    }
    void OnMouseExit()
    {
        isHovering = false;
    }

    IEnumerator FlipRoutine()
    {
        CardIdentity identity = GetComponent<CardIdentity>();
        if (identity == null) yield break;

        int currentRank = identity.cardData.rank;
        if (currentRank != 3 && currentRank != 6) yield break;

        isFlipping = true;

       
        yield return RotateOverTime(90f);

     
        CardData newData = identity.cardData;
        newData.rank = (currentRank == 3) ? 6 : 3;
        identity.cardData = newData;

       
        yield return RotateOverTime(90f);

        isFlipping = false;
    }
    IEnumerator RotateOverTime(float degrees)
    {
        float elapsed = 0f;
        Quaternion startRot = transform.rotation;
        Quaternion endRot = startRot * Quaternion.Euler(degrees, 0f, 0f);

        while (elapsed < flipDuration)
        {
            elapsed += Time.deltaTime;
            transform.rotation = Quaternion.Slerp(startRot, endRot, elapsed / flipDuration);
            yield return null;
        }

        transform.rotation = endRot;
    }
    /*public void TryFlip()
    {
        int currentRank = display.cardData.rank;

        if (currentRank != 3 && currentRank != 6) return;

        CardData newData= display.cardData;
        newData.rank=(currentRank==3)?6:3;

        display.SetCard(newData);
        transform.Rotate(0f, 180f, 0f);
    }*/


}
