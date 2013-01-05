using System.Collections.Generic;

namespace ScoreParser {
    public class Games {
        private readonly ITeamManager _teamManager;

        public Games(ITeamManager teamManager) {
            _teamManager = teamManager;
        }

        private List<Game> games = new List<Game>();

        public int Count {
            get { return games.Count; }
        }

        public void AddMultiple(string[] lines) {
            foreach (string gameDescription in lines) {
                Game game = new Game(_teamManager);
                game.InitFromGameDescription(gameDescription);
                games.Add(game);
            }
        }

        public IEnumerable<Game> GetGames() {
            return games;
        }
    }
}