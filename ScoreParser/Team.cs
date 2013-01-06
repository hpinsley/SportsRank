using System.Collections.Generic;

namespace ScoreParser {
    public class Team {

        public string Name { get; private set; }
        public int Wins { get; private set; }
        public int Losses { get; private set; }
        public int Ties { get; private set; }
        public int Grade { get; private set; }
        public string Record {
            get { return string.Format("{0}-{1}-{2}", Wins, Losses, Ties); }
        }

        private List<Game> _games = new List<Game>();

        public Team(string name) {
            Name = name;
        }

        public void AddWin() {
            ++Wins;
        }

        public void AddLoss() {
            ++Losses;
        }

        public void AddTie() {
            ++Ties;
        }

        public void AddGame(Game game) {
            _games.Add(game);
        }

        public void IncrementGrade(int amount) {
            Grade += amount;
        }

        public IEnumerable<Game> GetGames() {
            return _games;
        }

        public override string ToString() {
            return Name;
        }

    }
}