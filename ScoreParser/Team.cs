namespace ScoreParser {
    public class Team {

        public string Name { get; private set; }
        public int Wins { get; private set; }
        public int Losses { get; private set; }
        public int Ties { get; private set; }
        public int Grade { get; private set; }

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

        public void IncrementGrade(int amount) {
            Grade += amount;
        }

        public override string ToString() {
            return string.Format("{0} {1}-{2}-{3}: Grade: {4}", Name, Wins, Losses, Ties, Grade);
        }
    }
}