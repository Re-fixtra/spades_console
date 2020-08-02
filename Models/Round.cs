namespace Models
{
    public class Round
    {
        public Bet Team1_Bet { get; set; }
        public Bet Team2_Bet { get; set; }
        public int Team1_Actual { get; set; }
        public int Team2_Actual { get; set; }
        public int Team1_RoundScore { get; set; }
        public int Team2_RoundScore { get; set; }
        public int Team1_TotalScore { get; set; }
        public int Team2_TotalScore { get; set; }

        public Round(Bet team1_bet, Bet team2_bet)
        {
            Team1_Bet = team1_bet;
            Team2_Bet = team2_bet;
        }

        public void PlayRound(){

        }
        
        //todo: calculate score for round
    }
}