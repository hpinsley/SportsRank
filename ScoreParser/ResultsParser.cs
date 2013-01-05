using System;
using System.IO;

namespace ScoreParser {
    public class ResultsParser {

        private ITeamManager _teamManager;

        public ResultsParser(ITeamManager teamManager) {
            _teamManager = teamManager;
        }

        public Games ParseGameResults(string gameResultsFile) {
            string[] lines = File.ReadAllLines(gameResultsFile);

            Games games = new Games(_teamManager);
            games.AddMultiple(lines);

            GradeTheTeams(games);
            return games;
        }

        private void GradeTheTeams(Games games) {
            foreach (Game game in games.GetGames()) {
                if (game.IsTie)
                    continue;

                game.Winner.IncrementGrade(game.Loser.Wins);
                game.Loser.IncrementGrade(-1 * game.Winner.Losses);
            }
        }
    }
}