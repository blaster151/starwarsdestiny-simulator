using Microsoft.Practices.Unity;
using SwdSim.Domain.Constructs;
using SwdSim.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwDestinyDb.Sandbox
{
    class Program
    {
        static void Main(string[] args)
        {
            IUnityContainer container = new UnityContainer();
            container.AddExtension(new SwdSim.Data.UnityIocModule());
            container.AddExtension(new SwDestinyDb.Api.UnityIocModule());

            var deckListId = "9311";

            var repo = container.Resolve<IDeckRepository>();
            var deck = repo.GetDestinyDeck(deckListId);

            WriteDeckToConsole(deck);
           
            Console.ReadKey();
        }

        static void WriteDeckToConsole(DestinyDeck deck)
        {
            Console.WriteLine("Destiny Deck");
            Console.WriteLine($"Total Points: {deck.TotalPoints}");
            Console.WriteLine("Characters:");
            foreach (var character in deck.Team)
            {
                Console.WriteLine($"\t{character.Name} - {character.Dice.Count} Dice @ {character.TotalPoints} points.");
            }
            Console.WriteLine("Draw Deck:");
            foreach (var card in deck.DrawDeck)
            {
                Console.WriteLine($"\t{card.Name}");
            }
            Console.WriteLine("Battlefield:");
            Console.WriteLine($"\t{deck.Battlefield.Name}");
        }
    }
}
