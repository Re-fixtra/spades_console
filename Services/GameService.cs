using Models;
using Enums;
using System;

namespace Services
{
    public class GameService
    {
        private Game Game;

        public GameService(Game game)
        {
            Game = game;
        }
        public void StartGame()
        {

            while (Game.GameStatus != GameState.Complete)
            { //todo update for ties etc

                //Get team bets
                Game.GetTeamBets();
                Game.DisplayTeamBets(Game.Team1);
                Game.DisplayTeamBets(Game.Team2);

                //Input completed round number of books for each player
                GetTeamActual();
                DisplayTeamActuals(Game.Team1);
                DisplayTeamActuals(Game.Team2);
                
                //Play next round
                var nextRound = new Round(new Bet(), new Bet());
                nextRound.PlayRound();

                Game.GameStatus = GameState.Complete;
            }
        }

        public void GetTeamActual()
        {
            string actualValue;
            int val;
            Console.Write($"Enter actual books won for {Game.Team1.Player1.Name}: ");
            actualValue = Console.ReadLine();
            int.TryParse(actualValue, out val);
            Game.Team1.Player1.Bets[Game.Rounds.Count].Actual = val;

            Console.Write($"Enter actual books won for {Game.Team2.Player2.Name}: ");
            actualValue = Console.ReadLine();
            int.TryParse(actualValue, out val);
            Game.Team1.Player2.Bets[Game.Rounds.Count].Actual = val;

            Console.Write($"Enter actual books won for {Game.Team2.Player1.Name}: ");
            actualValue = Console.ReadLine();
            int.TryParse(actualValue, out val);
            Game.Team2.Player1.Bets[Game.Rounds.Count].Actual = val;

            Console.Write($"Enter actual books won for {Game.Team2.Player2.Name}: ");
            actualValue = Console.ReadLine();
            int.TryParse(actualValue, out val);
            Game.Team2.Player2.Bets[Game.Rounds.Count].Actual = val;
        }

        public void DisplayTeamActuals(Team team)
        {
            Console.WriteLine("Actuals for Team");
            Console.WriteLine($"Name: {team.Player1.Name}\nBet: {team.Player1.Bets[Game.Rounds.Count].Books} <=> Actual: {team.Player1.Bets[Game.Rounds.Count].Actual}");
            Console.WriteLine($"Name: {team.Player2.Name}\nBet: {team.Player2.Bets[Game.Rounds.Count].Books} <=> Actual: {team.Player2.Bets[Game.Rounds.Count].Actual}");
            Console.WriteLine($"Total Actual: {team.Player1.Bets[Game.Rounds.Count].Actual + team.Player2.Bets[Game.Rounds.Count].Actual}");
        }
    }
}