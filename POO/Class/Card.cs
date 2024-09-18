namespace POO.Class
{
    public enum eSuit
    {
        Oros,
        Copas,
        Espadas,
        Bastos
    }

    public class Card
    {
        public eSuit Suit { get; private set; }
        public int Value { get; private set; }

        public Card(eSuit suit, int value)
        {
            Suit = suit;
            Value = value;
        }

        public override string ToString()
        {
            return $"{Value} de {Suit}";
        }
    }
}
