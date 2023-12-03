using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KartGame
{
    public class Game
{
    private List<Player> players;
    private List<Karta> deck;

    
    public Game(params string[] Kplayers)
    {
        if (Kplayers.Length < 2)
        {
            throw new ArgumentException("Должно быть как минимум 2 игрока");
        }

        
        players = Kplayers.Select(name => new Player(name)).ToList();
        deck = GenerateDeck();
        DealCards();
    }

    private List<Karta> GenerateDeck()
    {
        List<Karta> newDeck = new List<Karta>();
        foreach (Mast mast in Enum.GetValues(typeof(Mast)))
        {
            foreach (KartaType type in Enum.GetValues(typeof(KartaType)))
            {
                newDeck.Add(new Karta(mast, type));
            }
        }
        return newDeck;
    }

    
    private void DealCards()
    {
        int cardsPerPlayer = deck.Count / players.Count;
        for (int i = 0; i < players.Count; i++)
        {
            players[i].AddCards(deck.Skip(i * cardsPerPlayer).Take(cardsPerPlayer).ToList());
        }
    }

    public void PlayGame()
    {
        
        while (!IsGameOver())
        {
            PlayRound();
        }

        Player winner = players.OrderByDescending(p => p.Cards.Count).First();
        Console.WriteLine($"{winner.Name} Победил!");
    }

    private void PlayRound()
    {
        List<Karta> cardsInPlay = players.Select(p => p.PlayCard()).ToList();

        int maxCardIndex = cardsInPlay.IndexOf(cardsInPlay.Max());
        Player roundWinner = players[maxCardIndex];

        foreach (Player player in players)
        {
            roundWinner.AddCards(player.GetPlayedCards());
        }

        Console.WriteLine($"{roundWinner.Name} Победил в раунде!");
    }

    private bool IsGameOver()
    {
        return players.Any(p => p.Cards.Count == deck.Count);
    }
}
}
