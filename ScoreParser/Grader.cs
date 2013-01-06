namespace ScoreParser {
    public static class Grader {

        public static int GradeTeamInGame(Team team, Game game) {
            if (game.IsTie)
                return 0;

            if (team == game.Winner)
                return game.Loser.Wins;

            return -1*game.Winner.Losses;
        }

        public static TeamAnalysis GetTeamGradeAnalysis(Team team) {
            TeamAnalysis analysis = new TeamAnalysis();
            int cumGrade = 0;
            foreach (Game game in team.GetGames()) {
                TeamGameAnalysis teamGameAnalysis = new TeamGameAnalysis(team, game);
                cumGrade += teamGameAnalysis.GameGrade;
                teamGameAnalysis.CumulativeGrade = cumGrade;
                analysis.AddTeamGameAnalysis(teamGameAnalysis);
            }
            return analysis;
        }
    }
}