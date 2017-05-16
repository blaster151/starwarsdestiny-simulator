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
            var api = new SwDestinyDb.Api.PublicApi();
            var sets = api.GetSets();
            foreach (var set in sets)
            {
                Console.WriteLine(set.name);                
                var cards = api.GetCards(set);
                foreach (var card in cards)
                {
                    Console.WriteLine($"\t{card.position} - {card.name}");
                }
            }
            var decklist = api.GetDeckList("9311");
            Console.ReadKey();
        }
    }
}
