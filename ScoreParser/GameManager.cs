using System.Collections.Generic;

namespace ScoreParser {
    public class GameManager : IGameManager {
        private readonly ITeamManager _teamManager;

        public GameManager(ITeamManager teamManager) {
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