namespace ScoreParser {
    public class TeamGameAnalysis {
        public Game Game { get; private set; }
        public Team Team { get; private set; }
        public Team OtherTeam { get; private set; }
        public string RelationshipToOtherTeam { get; private set; }
        public int GameGrade { get; private set; }
        public int CumulativeGrade { get; set; }

        public TeamGameAnalysis(Team team, Game game) {
            Team = team;
            Game = game;

            if (team == game.Winner) {
                OtherTeam = game.Loser;
                RelationshipToOtherTeam = "defeated";
            }
            else {
                OtherTeam = game.Winner;
                RelationshipToOtherTeam = "lost to";
            }

            if (game.IsTie) {
                RelationshipToOtherTeam = "tied";
            }

            GameGrade = Grader.GradeTeamInGame(team, game);
        }

    }
}