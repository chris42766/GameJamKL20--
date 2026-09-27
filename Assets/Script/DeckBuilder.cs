using UnityEngine;
using System.Collections.Generic;
public static class DeckBuilder
{
  
    public static List<CardData> BuildDeck()
    {
        var deck = new List<CardData>();
        foreach (Suit s in System.Enum.GetValues(typeof(Suit)))
            for (int r = 1; r <= 13; r++)
                deck.Add(new CardData { suit = s, rank = r });
        return deck;
                }

    public static void Shuffle (List<CardData> deck)
    {
        System.Random rng = new System.Random();
        int n = deck.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            (deck[k], deck[n]) = (deck[n], deck[k]);
        }

    }
}
