namespace POO.Class
{
    public enum Suit
    {
        Oros,
        Copas,
        Espadas,
        Bastos
    }

    public class Card
    {
        public Suit Suit { get; private set; }
        public int Value { get; private set; }

        public Card(Suit suit, int value)
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
