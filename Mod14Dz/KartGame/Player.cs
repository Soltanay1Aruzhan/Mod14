using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KartGame
{
    public class Player
    {
        public string Name { get; }
        public List<Karta> Cards { get; }

        private List<Karta> playedCards;

        public Player(string name)
        {
            Name = name;
            Cards = new List<Karta>();
            playedCards = new List<Karta>();
        }

        public Karta PlayCard()
        {
            Karta cardToPlay = Cards.First();
            playedCards.Add(cardToPlay);
            Cards.RemoveAt(0);
            return cardToPlay;
        }

        public void AddCards(List<Karta> cards)
        {
            Cards.AddRange(cards);
        }

        public List<Karta> GetPlayedCards()
        {
            List<Karta> played = playedCards.ToList();
            playedCards.Clear();
            return played;
        }

        public override string ToString()
        {
            return $"{Name} has {Cards.Count} cards.";
        }
    }
}
