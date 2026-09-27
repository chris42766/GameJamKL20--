using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Rendering;
public class DeckSpawner : MonoBehaviour
{
    public GameObject cardPrefab;
    public Vector2 tableAreaSize = new Vector2(8f, 5f);
    public float cardYHeight = 0.1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        List<CardData> deck = DeckBuilder.BuildDeck();
        DeckBuilder.Shuffle(deck);

        foreach (CardData card in deck)
        {
            Vector3 pos = new Vector3(Random.Range(-tableAreaSize.x / 2, tableAreaSize.x / 2), cardYHeight, Random.Range(-tableAreaSize.y / 2, tableAreaSize.y / 2));

            GameObject obj =Instantiate(cardPrefab, pos, Quaternion.identity,transform);
            obj.GetComponent<CardDisplay>().SetCard(card);
        }
    }

    // Update is called once per frame

}
