namespace POO.Class
{
    public class Card
    {
        public string Suit { get; private set; }
        public int Value { get; private set; }

        public Card(string suit, int value)
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
