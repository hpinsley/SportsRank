using System;
using ScoreParser;

namespace NFLRanking {
    class Program {
        static void Main() {
            GetStats();
        }

        private const string NFL2012 = @"C:\Users\pinsley\Google Drive\NFL Results\NFL-2012-Results.txt";

        protected static void LogMsg(string fmt, params object[] args) {
            string msg = string.Format(fmt, args);
            LogMsg(msg);
        }

        protected static void LogMsg(string msg) {
            Console.WriteLine(msg);
        }

        public static void GetStats() {
            ITeamManager teamManager = new TeamManager();
            ResultsParser parser = new ResultsParser(teamManager);
            Games games = parser.ParseGameResults(NFL2012);

            foreach (Game game in games.GetGames()) {
                LogMsg(game.ToString());
            }

            foreach (Team team in teamManager.GetTeams()) {
                LogMsg("{0} is graded a {1}", team, team.Grade);
            }

            Team giants = teamManager.GetTeam("NY Giants");
            ShowTeamGames(giants);

        }

        private static void ShowTeamGames(Team team) {
            LogMsg("Games for {0}", team.Name);
            int cumGrade = 0;
            int delta;
            foreach (Game game in team.GetGames()) {
                if (game.IsTie) {
                    LogMsg("{0} tied {1}",
                           team.Name, (team == game.Winner) ? game.Loser.Name : game.Winner.Name);
                }
                else if (team == game.Winner) {
                    delta = game.Loser.Wins;
                    cumGrade += delta;
                    Console.WriteLine("{0} beat {1} {2} {3}\tCredit:{4} Total:{5}", team.Name, game.Loser.Record, game.Loser, game.Score, delta, cumGrade);
                }
                else if (team == game.Loser) {
                    delta = -1 * game.Winner.Losses;
                    cumGrade += delta;
                    Console.WriteLine("{0} lost to {1} {2} {3}\tCredit:{4} Total:{5}", team.Name, game.Winner.Record, game.Winner, game.Score, delta, cumGrade);
                }
            }
            LogMsg("\n{0} final grade is {1}", team.Name, team.Grade);
        }
    }
}
