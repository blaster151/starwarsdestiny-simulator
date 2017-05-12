using SwdSim.Domain.Constructs.Cards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwdSim.Domain.Constructs
{
    public class Deck : Stack<Card>
    {
        public void Shuffle()
        {
            var cards = this.ToList();
            this.Clear();
            var random = new Random();
            cards.OrderBy(c => random.Next()).ToList().ForEach(c =>
            {
                this.Push(c);
            });
        }
    }

}
