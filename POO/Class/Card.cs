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
        public Suit eSuit { get; private set; }
        public int Value { get; private set; }

        public Card(Suit esuit, int value)
        {
            eSuit = esuit;
            Value = value;
        }

        public override string ToString()
        {
            return $"{Value} de {eSuit}";
        }
    }
}
