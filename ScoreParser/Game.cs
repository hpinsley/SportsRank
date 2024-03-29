﻿using System;

namespace ScoreParser {
    public class Game {
        private readonly ITeamManager _teamManager;

        public string GameDescription { get; private set; }
        public Team Winner { get; private set; }
        public Team Loser { get; private set; }
        public bool IsTie { get; private set; }
        public string Score { get; private set; }

        public Game(ITeamManager teamManager) {
            _teamManager = teamManager;
        }

        public override string ToString() {
            return string.Format("{0} over {1} {2} {3}",
                                 Winner, Loser, Score, IsTie ? "A Tie!" : "");
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

            int score1 = teamAndScore1.Item2;
            int score2 = teamAndScore2.Item2;
            Score = score1 > score2 ? string.Format("{0}-{1}", score1, score2) : string.Format("{0}-{1}", score2, score1);
            IsTie = score1 == score2;

            if (IsTie) {
                Winner.AddTie();
                Loser.AddTie();
            }
            else {
                Winner.AddWin();
                Loser.AddLoss();
            }
            Winner.AddGame(this);
            Loser.AddGame(this);
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