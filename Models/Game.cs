using System;
using System.Collections.Generic;
using Enums;

namespace Models
{
    public class Game
    {
        public IList<Round> Rounds { get; set; }
        public Team Team1 { get; set; }
        public Team Team2 { get; set; }
        public GameState GameStatus { get; set; }
        public Game(Team team1, Team team2)
        {
            Team1 = team1;
            Team2 = team2;
            Rounds = new List<Round>();
            GameStatus = GameState.InProgress;
        }

        public void GetTeamBets()
        {
            string betValue;
            int val;
            Console.Write($"Enter bet for {Team1.Player1.Name}: ");
            betValue = Console.ReadLine();
            int.TryParse(betValue, out val);
            Team1.Player1.Bets[Rounds.Count] = new Bet { Books = val };

            Console.Write($"Enter bet for {Team1.Player2.Name}: ");
            betValue = Console.ReadLine();
            int.TryParse(betValue, out val);
            Team1.Player2.Bets[Rounds.Count] = new Bet { Books = val };

            Console.Write($"Enter bet for {Team2.Player1.Name}: ");
            betValue = Console.ReadLine();
            int.TryParse(betValue, out val);
            Team2.Player1.Bets[Rounds.Count] = new Bet { Books = val };

            Console.Write($"Enter bet for {Team2.Player2.Name}: ");
            betValue = Console.ReadLine();
            int.TryParse(betValue, out val);
            Team2.Player2.Bets[Rounds.Count] = new Bet { Books = val };

        }

        public void DisplayTeamBets(Team team)
        {
            Console.WriteLine("Bets for Team");
            Console.WriteLine($"Name: {team.Player1.Name} - Bet: {team.Player1.Bets[Rounds.Count].Books}");
            Console.WriteLine($"Name: {team.Player2.Name} - Bet: {team.Player2.Bets[Rounds.Count].Books}");
            Console.WriteLine($"Total Bet: {team.Player1.Bets[Rounds.Count].Books + team.Player2.Bets[Rounds.Count].Books}\n");
        }

        public int GetCurrentRoundNumber()
        {
            return Rounds.Count + 1;
        }
    }
}