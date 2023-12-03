using KartGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Mod14Dz
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            Game game = new Game("Player1", "Player2");
            game.PlayGame();

            
            string text = "Бұл Джек салған үй. Ал мынау Джек салған үйдегі қараңғы шкафта сақталатын бидай. Ал мынау бидайды жиі ұрлайтын, Джек салған үйде қараңғы шкафта сақталатын көңілді құс.";

            Dictionary<string, int> wordCount = CountWords(text);

            DisplayStatistics(wordCount);
        }

        static Dictionary<string, int> CountWords(string text)
        {
            Dictionary<string, int> wordCount = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
            string[] words = text.Split(new char[] { ' ', '.', ',', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string word in words)
            {
                if (wordCount.ContainsKey(word))
                {
                    wordCount[word]++;
                }
                else
                {
                    wordCount[word] = 1;
                }
            }

            return wordCount;
        }

        static void DisplayStatistics(Dictionary<string, int> wordCount)
        {
            Console.WriteLine("| Сөз            | Саны       |");
            Console.WriteLine("|----------------|------------|");

            foreach (var kvp in wordCount.OrderByDescending(x => x.Value))
            {
                Console.WriteLine($"| {kvp.Key,-15} | {kvp.Value,-10} |");
            }
        }

    }

}
