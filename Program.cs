using System;
using Models;
using Services;

namespace spades_console
{
    class Program
    {
        static void Main(string[] args)
        {
            //How do we complete team selection, client side?
            //Create teams
            var team1 = new Team("t1_p1","t1_p2");
            var team2 = new Team("t2_p1", "t2_p2");

            //Create game
            var game = new Game(team1, team2);
            var gameService = new GameService(game);

            //Start the game
            gameService.StartGame();
            
            // Console.WriteLine(game.Rounds.Count);
            // Console.WriteLine(team1.Player1.Bets[0].Books);

            // Notes
            // Do I need a service for each model?
        }
    }
}
