using System.Collections.Generic;

namespace Models
{
    public class Player
    {
        public IList<Bet> Bets { get; set; }
        public string Name { get; set; }

        public Player(string name)
        {
            Name = name;
            Bets = new Bet[20];
        }
    }
}