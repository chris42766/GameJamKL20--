using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class CardDisplay : MonoBehaviour
{
    public TextMeshProUGUI suitText;
    public TextMeshProUGUI rankText;


    static readonly string[] rankNames= {"A","2","3","4","5","6","7","8","9","10","J","Q","K" };
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    static readonly Dictionary<Suit, string> suitSymbols = new Dictionary<Suit, string>
    {
        {Suit.Hearts,"♥" },
        {Suit.Diamonds,"♦" },
        {Suit.Spades,"♠" },
        {Suit.Clubs,"♥" },
    };

    static readonly Dictionary<Suit, Color> suitColors = new Dictionary<Suit, Color>
    {
        {Suit.Hearts,Color.red },
        {Suit.Diamonds,Color.red },
        {Suit.Clubs,Color.black },
        {Suit.Spades,Color.black },
    };

    public void SetCard(CardData data)
    {
        rankText.text = rankNames[data.rank - 1];
        suitText.text = suitSymbols[data.suit];

        Color c = suitColors[data.suit];
        suitText.color = c;
        rankText.color = c;
    }
    // Update is called once per frame

}
