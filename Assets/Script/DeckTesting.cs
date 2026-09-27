using NUnit.Framework;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using JetBrains.Annotations;
public class DeckTesting : MonoBehaviour,IPointerDownHandler,IPointerUpHandler,IPointerClickHandler,IPointerEnterHandler,IPointerExitHandler
{
    public List<CardPrefabEntry> cardPrefabs;
    private Dictionary<(Suit, int), GameObject> prefabLookup;

    public Vector3 spawnPosition = new Vector3(-0.5f, 0.69f, 0f);
    public float movePosition = 3.28f;
    private List<CardData> deck;
    private List<GameObject> spawnedCards = new List<GameObject>();

    float cooldown = 2f;
    public void RegisterSpawnedCard(GameObject card)
    {
        spawnedCards.Add(card);
    }

    private int cardsDealt = 0;

    public AddPlayAreaScript apaScript;
    public TensPlayAreaScript tpaScript;

    //public AddPlayAreaScript apaScript;
    //public TensPlayAreaScript tpaScript;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    // private MaterialApplier matrialApplier;
    private void Awake()
    {
        prefabLookup = new Dictionary<(Suit, int), GameObject>();
        foreach (var entry in cardPrefabs)
            prefabLookup[(entry.suit, entry.rank)] = entry.prefab;
    }
    private void Start()
    {
        BuildAndShuffleDeck();
    }
    void Update()
    {
        if (apaScript.nextRoundAdd && tpaScript.nextRoundTen)
        {
            if (cooldown > 0f)
            {
                cooldown -= Time.deltaTime;
            }
            else if (cooldown < 0f)
            {
                ResetRound();
            }
        }
    }
    public void OnPointerDown(PointerEventData eventData)
    {
    
    }

    public void OnPointerUp(PointerEventData eventData) { 
    
    
    }

    public void OnPointerClick(PointerEventData eventData) {
        //Debug.Log("gg");
        if (cardsDealt <= 4)
        {

            DealNextCard();
        }
    }

    public void OnPointerEnter(PointerEventData eventData) {
        //ebug.Log("Holey");
    }
    public void OnPointerExit(PointerEventData eventData) { 
    }
    
    
    public void BuildAndShuffleDeck()
    {
        deck=DeckBuilder.BuildDeck();
        DeckBuilder.Shuffle(deck);
        cardsDealt = 0;


    }

    public void DealNextCard()
    {
        if (cardsDealt >= deck.Count) { 
        
        BuildAndShuffleDeck();// shuffle new deck cuz 52 all grab
            return;
        }
        if (cardsDealt != 0)
        {
            spawnPosition.x += movePosition;
        }
        CardData data = deck[cardsDealt];
        cardsDealt++;

        GameObject prefabToUse = prefabLookup[(data.suit, data.rank)];
        GameObject obj = Instantiate(prefabToUse, spawnPosition, Quaternion.Euler(0,90f,90f));

        CardIdentity identity = obj.AddComponent<CardIdentity>();
        identity.cardData = data;
        spawnedCards.Add(obj);
       // Debug.Log($"Rank: {display.cardData.rank}, CardValue: {display.cardData.CardValue}");
        //Debug.Log(display.cardData.CardValue);
    }
    public GameObject GetPrefabFor(Suit suit,int rank)
    {
        return prefabLookup[(suit, rank)];
    }
   /* public void ShowRandomCard()
    {
        Suit randomSuit = (Suit)Random.Range(0, 4);
        int randomRank = Random.Range(1, 14);

        CardData data = new CardData { suit = randomSuit, rank = randomRank };

        GameObject obj = Instantiate(cardPrefab, spawnPosition, Quaternion.identity);
        obj.GetComponent<CardDisplay>().SetCard(data);
    }*/
   
    public void ResetRound()
    {
        foreach(GameObject card in spawnedCards)
        {
            if (card != null)
            {
                Destroy(card);
            }
            //spawnedCards.Clear();
        }
        spawnedCards.Clear();
        cardsDealt = 0;
        spawnPosition = new Vector3(-19f, -27.3f, -10.24f);
        apaScript.totalNumber = 0;
        apaScript.cardPlayed = 0;
        apaScript.nextRoundAdd = false;
        apaScript.stopLoop= false;

        tpaScript.totalNumber = 0;
        tpaScript.cardPlayed = 0;
        tpaScript.nextRoundTen = false;
        tpaScript.stopLoop = false;

        cooldown = 2f;

        BuildAndShuffleDeck();
    }
}
