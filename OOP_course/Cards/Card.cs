using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Cards
{
    public class Card
    {
        private HashSet<string> validFaces = new HashSet<string>()
        { 
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "J",
            "Q",
            "K",
            "A"

        };
        private HashSet<string> validSuit = new HashSet<string>()
        {
            "S", "H", "D", "C"
        };

        public Card(string face, string suit)
        {
            if (!validFaces.Contains(face)|| (!validSuit.Contains(suit)))
                throw new ArgumentException("Invalid card!");

            this.Face = face;
            this.Suit = suit;
        }

        public string Face { get; }
        public string Suit { get; }
        public override string ToString()
        {
            char displaySuit = this.Suit switch
            {
                "S" => '\u2660',
                "H" => '\u2665',
                "D" => '\u2666',
                "C" => '\u2663'
            };
            return $"[{this.Face}{displaySuit}]";
        }
    }
}
