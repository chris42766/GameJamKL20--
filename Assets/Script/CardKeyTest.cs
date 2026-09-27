using UnityEngine;

public class CardKeyTest : MonoBehaviour
{
    public GameObject cardPrefab;
    public Vector3 spawnPosition=new Vector3(0f,0f,0f);

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            ShowRandomCard();

        }
    }


    public void ShowRandomCard()
    {
        Suit randomSuit = (Suit)Random.Range(0, 4);
        int randomRank = Random.Range(1, 14);

        CardData data= new CardData { suit=randomSuit, rank=randomRank };

        GameObject obj=Instantiate (cardPrefab,spawnPosition,   Quaternion.identity);
        obj.GetComponent<CardDisplay>().SetCard(data);
    }
}
