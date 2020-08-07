using Models;
using Enums;
using System;

namespace Services
{
    public class GameService
    {
        private Game Game;
        private readonly int GAME_FINAL_SCORE =  180;
        public GameService(Game game)
        {
            Game = game;
        }
        public void StartGame()
        {
            var roundLimit = 1;
            while (Game.GameStatus != GameState.Complete)
            { //todo update for ties etc

                //Play next round
                Console.WriteLine($"\nCurrent Round: {Game.GetCurrentRoundNumber()}");
                var nextRound = new Round(new Bet(), new Bet());
                Game.Rounds.Add(nextRound);
                Console.WriteLine($"After Adding New Round: {Game.GetCurrentRoundNumber()}");

                //Get team bets
                Game.GetTeamBets();
                Game.DisplayTeamBets(Game.Team1);
                Game.DisplayTeamBets(Game.Team2);

                //Input completed round number of books for each player
                GetTeamActual();
                DisplayTeamActuals(Game.Team1, Game.Rounds.Count);
                DisplayTeamActuals(Game.Team2, Game.Rounds.Count);

                //Store and output score
                CalculateGameScore(Game);
                //DisplayGameStats();

                if (Game.Team1.CurrentScore >= GAME_FINAL_SCORE || Game.Team2.CurrentScore >= GAME_FINAL_SCORE)
                {
                    Game.GameStatus = GameState.Complete;
                }
                else
                {
                    roundLimit++;
                }
            }
        }

        private void GetTeamActual()
        {
            string actualValue;
            int val;
            Console.Write($"Enter actual books won for {Game.Team1.Player1.Name}: ");
            actualValue = Console.ReadLine();
            int.TryParse(actualValue, out val);
            Game.Team1.Player1.Bets[Game.Rounds.Count].Actual = val;

            Console.Write($"Enter actual books won for {Game.Team1.Player2.Name}: ");
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

        private void DisplayTeamActuals(Team team, int roundCount)
        {
            Console.WriteLine($"\nActuals for Team: Round {roundCount}");
            Console.WriteLine($"Name: {team.Player1.Name}\nBet: {team.Player1.Bets[Game.Rounds.Count].Books} <=> Actual: {team.Player1.Bets[Game.Rounds.Count].Actual}");
            Console.WriteLine($"Name: {team.Player2.Name}\nBet: {team.Player2.Bets[Game.Rounds.Count].Books} <=> Actual: {team.Player2.Bets[Game.Rounds.Count].Actual}");
        }

        private void CalculateGameScore(Game game)
        {
            Console.WriteLine("\nTeam 1");
            CalculateRoundScoreForTeam(game.Team1);

            Console.WriteLine("\nTeam 2");
            CalculateRoundScoreForTeam(game.Team2);
        }

        private void CalculateRoundScoreForTeam(Team team)
        {
            int score = team.CurrentScore;
            var player1 = team.Player1;
            var player2 = team.Player2;
            var currentRound = Game.Rounds.Count;

            //Get Bets
            var player1_bet = player1.Bets[currentRound].Books;
            var player2_bet = player2.Bets[currentRound].Books;
            var totalBet = player1_bet + player2_bet;

            //Get Actuals
            var player1_actual = player1.Bets[currentRound].Actual;
            var player2_actual = player2.Bets[currentRound].Actual;
            var totalActual = player1_actual + player2_actual;

            Console.WriteLine($"\nTeam Score\nTotal Actual: {totalActual}\nTotal Bet: {totalBet}\n");
            //Calculate Score
            if (totalActual >= totalBet)
            { //todo double check edge cases
                score = totalBet * 10;

                if ((player1.Bets[currentRound].IsNil || player1.Bets[currentRound].IsBlindNil) && player1_actual == 0)
                {
                    if (player1.Bets[currentRound].IsBlindNil)
                    {
                        score += 200;
                    }
                    else //NIL
                    {
                        score += 100;
                    }
                }

                if ((player2.Bets[currentRound].IsNil || player2.Bets[currentRound].IsBlindNil) && player2_actual == 0)
                {
                    if (player2.Bets[currentRound].IsBlindNil)
                    {
                        score += 200;
                    }
                    else //NIL
                    {
                        score += 100;
                    }
                }
            }
            else
            {
                Console.WriteLine("Team did not make bet!");
                Console.WriteLine($"{score} - {totalBet * 10}");
                score = -(totalBet * 10);
            }

            Console.WriteLine($"Current Score:  {team.CurrentScore} + {score}");
            team.CurrentScore += score;
            Console.WriteLine($"Updated Score: {team.CurrentScore}");
        }
    }
}