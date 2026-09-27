public enum Suit { Hearts, Spades, Diamonds, Clubs}

[System.Serializable]
public struct CardData

{
    public Suit suit;
    public int rank;

    public int CardValue
    {
        get {
            if (rank == 1)
            {
                return 1;
            }
            if (rank >= 11)
            {
                return 10;
            }
            return rank;
        }
    } 

}