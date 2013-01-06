using System.IO;

namespace ScoreParser {
    public class ResultsParser : IResultsParser {
        private IGameManager _gameManager;

        public ResultsParser(IGameManager gameManager) {
            _gameManager = gameManager;
        }

        public void ParseGameResults(string gameResultsFile) {
            string[] lines = File.ReadAllLines(gameResultsFile);
            _gameManager.AddMultiple(lines);
            GradeTheTeams();
        }

        private void GradeTheTeams() {
            foreach (Game game in _gameManager.GetGames()) {
                game.Winner.IncrementGrade(Grader.GradeTeamInGame(game.Winner, game));
                game.Loser.IncrementGrade(Grader.GradeTeamInGame(game.Loser, game));
            }
        }
    }
}