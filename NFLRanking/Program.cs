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
                LogMsg("Team Manager has {0}", team);
            }
        }

    }
}
