namespace POO.Class
{
    public enum eSpanishSuit
    {
        Oros,
        Copas,
        Espadas,
        Bastos
    }

    public enum ePokerSuit
    {
        Corazones,
        Diamantes,
        Tréboles,
        Picas
    }

    public enum PokerCardValue
    {
        Dos = 2,
        Tres = 3,
        Cuatro = 4,
        Cinco = 5,
        Seis = 6,
        Siete = 7,
        Ocho = 8,
        Nueve = 9,
        Diez = 10,
        J = 11,    // Jota
        Q = 12,    // Reina
        K = 13,    // Rey
        A = 14     // As
    }

    public enum PokerHand
    {
        RoyalFlush,
        StraightFlush,
        FourOfAKind,
        FullHouse,
        Flush,
        Straight,
        ThreeOfAKind,
        TwoPair,
        OnePair,
        HighCard
    }

    public class Card
    {
        public object Suit { get; private set; }  // Puede ser eSpanishSuit o ePokerSuit
        public int Value { get; private set; }

        public Card(object suit, int value)
        {
            Suit = suit;
            Value = value;
        }

        public static int CompareByValue(Card card1, Card card2)
        {
            return card1.Value.CompareTo(card2.Value);
        }

        public static bool CompareSuits(Card card1, Card card2)
        {
            return card1.Suit.Equals(card2.Suit);
        }

        public override string ToString()
        {
            string valueString;
            if (Suit is ePokerSuit)
            {
                if (Value == 11)
                    valueString = "J";
                else if (Value == 12)
                    valueString = "Q";
                else if (Value == 13)
                    valueString = "K";
                else if (Value == 14)
                    valueString = "A";
                else
                    valueString = Value.ToString();

                return $"{valueString} de {Suit}";
            }
            else
            {
                return $"{Value} de {Suit}";
            }
        }
    }
}
