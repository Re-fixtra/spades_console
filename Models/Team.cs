namespace Models
{
    public class Team
    {
        public Player Player1 { get; set; }
        public Player Player2 { get; set; }
        public int CurrentScore { get; set; }
        public int Bags { get; set; }
        public Team(string player1Name, string player2Name)
        {
            Player1 = new Player(player1Name);
            Player2 = new Player(player2Name);
        }
    }
}