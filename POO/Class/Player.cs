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

        // Recibir una carta
        public void ReceiveCard(Card card)
        {
            Cards.Enqueue(card);
        }

        // Jugar la carta superior del paquete
        public Card PlayCard()
        {
            return Cards.Count > 0 ? Cards.Dequeue() : null;
        }

        // Ganar una mano y añadir las cartas ganadas al final del paquete
        public void WinHand(List<Card> wonCards)
        {
            foreach (var card in wonCards)
            {
                Cards.Enqueue(card);
            }
        }

        // Verificar si el jugador se quedó sin cartas
        public bool OutOfCards()
        {
            return Cards.Count == 0;
        }
    }
}
