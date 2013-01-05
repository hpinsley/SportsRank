using System;

namespace ScoreParser {
    public class Game {
        private readonly ITeamManager _teamManager;

        public string GameDescription { get; private set; }
        public Team Winner { get; private set; }
        public Team Loser { get; private set; }
        public bool IsTie { get; private set; }

        public Game(ITeamManager teamManager) {
            _teamManager = teamManager;
        }

        public override string ToString() {
            return string.Format("Game:[{0}]; Winner:{1} Loser:{2} {3}",
                                 GameDescription, Winner, Loser, IsTie ? "A Tie!" : "");
        }

        public void InitFromGameDescription(string gameDescription) {
            GameDescription = gameDescription;
            string[] split = gameDescription.Split(new[] {','});
            Tuple<string, int> teamAndScore1, teamAndScore2;

            teamAndScore1 = GetTeamAndScore(split[0]);
            teamAndScore2 = GetTeamAndScore(split[1]);

            if (teamAndScore2.Item2 > teamAndScore1.Item2) {
                Winner = _teamManager.GetTeam(teamAndScore2.Item1);
                Loser = _teamManager.GetTeam(teamAndScore1.Item1);
            }
            else {
                Winner = _teamManager.GetTeam(teamAndScore1.Item1);
                Loser = _teamManager.GetTeam(teamAndScore2.Item1);
            }

            IsTie = teamAndScore1.Item2 == teamAndScore2.Item2;

            if (IsTie) {
                Winner.AddTie();
                Loser.AddTie();
            }
            else {
                Winner.AddWin();
                Loser.AddLoss();
            }
        }

        private Tuple<string, int> GetTeamAndScore(string teamAndScore) {
            int index = teamAndScore.LastIndexOf(' ');
            string teamName = teamAndScore.Substring(0, index).Trim();
            string scoreString = teamAndScore.Substring(index + 1);
            int score = int.Parse(scoreString);
            return new Tuple<string, int>(teamName, score);
        }
    }
}