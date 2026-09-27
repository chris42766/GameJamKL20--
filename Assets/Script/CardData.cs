public enum Suit { Hearts, Spades, Diamonds, Clubs}

[System.Serializable]
public struct CardData

{
    public Suit suit;
    public int rank;
}