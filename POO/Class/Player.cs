using System.Collections.Generic;

namespace POO.Class
{
    public class Player
    {
        public string Name { get; private set; }
        public Queue<Card> Cards { get; private set; }

        public Player(string name)
        {
            Name = name;
            Cards = new Queue<Card>();
        }
    }
}
