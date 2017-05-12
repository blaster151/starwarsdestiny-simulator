using SwdSim.Domain.Constructs.Cards;
using SwdSim.Domain.Constructs;
using System.Collections.Generic;
using System;
using SwdSim.Domain.Exceptions;
using System.Linq;

namespace SwdSim.Domain
{
    public class Player
    {
        public readonly DestinyDeck Deck;

        public readonly Deck DiscardPile;
        public readonly Deck DrawPile;
        public readonly List<Character> Characters;
        public readonly Battlefield Battlefield;
        public readonly SetAsideArea SetAsideArea;
        public readonly List<Card> Hand;

        public Player(DestinyDeck deck)
        {
            Deck = deck;
            DiscardPile = new Deck();
            SetAsideArea = new SetAsideArea();
            Characters = new List<Character>(Deck.Team);
            DrawPile = new Deck();
            Hand = new List<Card>();
            foreach (var card in Deck.DrawDeck)
            {
                DrawPile.Push(card);
            }
           
            Battlefield = deck.Battlefield;
           
        }

        public void Setup()
        {
            DrawPile.Shuffle();
            Enumerable.Range(1, 5).ToList().ForEach(i => DrawCard());
            //todo - RolllOff
        }

        public void DrawCard()
        {
            if (DrawPile.Count == 0) throw new DrawPileEmptyException("Draw Pile is Empty - Unable to Draw");
            Hand.Add(DrawPile.Pop());
        }
    }

   
  
}
