using UnityEngine;
using UnityEngine.UI;
public class CardSpawningSystem : MonoBehaviour
{
   // public GameObject cardstemplate;
    int cardvalue;
    int cardnumber;
    void Awake()
    {
        cardvalue=Random.Range(1,14);
    }
    void Start()
    {
        Debug.Log(cardvalue);

        cardnumber = cardvalue;

    }
    public enum Suit { Hearts,Diamonds,Spades,Clubs}
    // Update is called once per frame

    void Update()
    {
        
    }
}
